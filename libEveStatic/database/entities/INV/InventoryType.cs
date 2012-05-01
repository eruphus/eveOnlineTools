/*
    Copyright 2012 Alexander Wölfel 
 
    This file is part of eveStatic.

    eveStatic is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License.

    eveStatic is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Foobar.  If not, see <http://www.gnu.org/licenses/>.

    Diese Datei ist Teil von eveStatic.

    EveStatic ist Freie Software: Sie können es unter den Bedingungen
    der GNU General Public License, wie von der Free Software Foundation,
    Version 3 der Lizenz weiterverbreiten und/oder modifizieren.

    EveStatic wird in der Hoffnung, dass es nützlich sein wird, aber
    OHNE JEDE GEWÄHELEISTUNG, bereitgestellt; sogar ohne die implizite
    Gewährleistung der MARKTFÄHIGKEIT oder EIGNUNG FÜR EINEN BESTIMMTEN ZWECK.
    Siehe die GNU General Public License für weitere Details.

    Sie sollten eine Kopie der GNU General Public License zusammen mit diesem
    Programm erhalten haben. Wenn nicht, siehe <http://www.gnu.org/licenses/>. 
 
 */

using System.Collections.Generic;
using System.Drawing;
using FluentNHibernate.Mapping;
using libEveStatic.database.entities.CHR;
using libEveStatic.database.entities.DGM;
using libEveStatic.database.entities.EVE;
using libEveStatic.database.entities.RAM;
using libEveStatic.pictures;
using libUtils.Core;
using Icon = libEveStatic.database.entities.EVE.Icon;

namespace libEveStatic.database.entities.INV
{
    /*
CREATE TABLE dbo.invTypes
(
  typeID               int,
  groupID              int,
  typeName             nvarchar(100)   COLLATE Latin1_General_CI_AI,
  description          nvarchar(3000),
  graphicID            int,
  radius               float,
  mass                 float,
  volume               float,
  capacity             float,
  portionSize          int,
  raceID               tinyint,
  basePrice            money,
  published            bit,
  marketGroupID        smallint,
  chanceOfDuplicating  float,
  iconID               int,
                                 
  CONSTRAINT invTypes_PK PRIMARY KEY CLUSTERED (typeID)
)	
ALTER TABLE invTypes ADD CONSTRAINT invTypes_FK_group FOREIGN KEY (groupID) REFERENCES invGroups(groupID)
ALTER TABLE invTypes ADD CONSTRAINT invTypes_FK_icon FOREIGN KEY (iconID) REFERENCES eveIcons(iconID)
ALTER TABLE invTypes ADD CONSTRAINT invTypes_FK_graphic FOREIGN KEY (graphicID) REFERENCES eveGraphics(graphicID)
ALTER TABLE invTypes ADD CONSTRAINT invTypes_FK_marketGroup FOREIGN KEY (marketGroupID) REFERENCES invMarketGroups(marketGroupID)
ALTER TABLE invTypes ADD CONSTRAINT invTypes_FK_race FOREIGN KEY (raceID) REFERENCES chrRaces(raceID)

     * invTypeMaterials
	typeID	int(10)	NO	PRI		
	materialTypeID	int(10)	NO	PRI		
	quantity	int(10)	NO		0	
     * * 
     * 
     * 
CREATE TABLE dbo.dgmTypeAttributes
(
  typeID       int,
  attributeID  smallint,
  valueInt     int,
  valueFloat   float,

  CONSTRAINT dgmTypeAttributes_PK PRIMARY KEY CLUSTERED (typeID, attributeID)
)
     * 
     * 
ALTER TABLE dgmTypeAttributes ADD CONSTRAINT dgmTypeAttributes_FK_type FOREIGN KEY (typeID) REFERENCES invTypes(typeID)
ALTER TABLE dgmTypeAttributes ADD CONSTRAINT dgmTypeAttributes_FK_attribute FOREIGN KEY (attributeID) REFERENCES dgmAttributeTypes(attributeID)
     
     
     
CREATE TABLE dbo.dgmTypeEffects
(
  typeID      int,
  effectID    smallint,
  isDefault   bit,

  CONSTRAINT dgmTypeEffects_PK PRIMARY KEY CLUSTERED(typeID, effectID)
)

     * 
     * 
ALTER TABLE dgmTypeEffects ADD CONSTRAINT dgmTypeEffects_FK_type FOREIGN KEY (typeID) REFERENCES invTypes(typeID)
ALTER TABLE dgmTypeEffects ADD CONSTRAINT dgmTypeEffects_FK_effects FOREIGN KEY (effectID) REFERENCES dgmEffects(effectID)

     * 
     * 
CREATE TABLE dbo.invControlTowerResources
(
  controlTowerTypeID  int,
  resourceTypeID      int,
  --
  purpose             tinyint,
  quantity            int,
  minSecurityLevel    float,
  factionID           int,

  CONSTRAINT invControlTowerResources_PK PRIMARY KEY CLUSTERED (controlTowerTypeID, resourceTypeID)
)

     
     * 
     * 
ALTER TABLE invControlTowerResources ADD CONSTRAINT invControlTowerResources_FK_faction FOREIGN KEY (factionID) REFERENCES chrFactions(factionID)
ALTER TABLE invControlTowerResources ADD CONSTRAINT invControlTowerResources_FK_resourceType FOREIGN KEY (resourceTypeID) REFERENCES invTypes(typeID)
ALTER TABLE invControlTowerResources ADD CONSTRAINT invControlTowerResources_FK_constrolTowerType FOREIGN KEY (controlTowerTypeID) REFERENCES invTypes(typeID)

     * 
     
CREATE TABLE dbo.ramInstallationTypeContents
(
  installationTypeID  int      NOT NULL,
  assemblyLineTypeID  tinyint  NOT NULL,
  --
  quantity            tinyint  NULL,
  CONSTRAINT ramInstallationTypeContents_PK PRIMARY KEY CLUSTERED (installationTypeID, assemblyLineTypeID)
)     */



    public class InventoryTypeMapper : ClassMap<InventoryType>
    {

        public InventoryTypeMapper()
        {
            Table("invTypes");
            Id(x => x.Id, "typeID");

            References(x => x.Group, "groupID").Nullable(); 
            References(x => x.MarketGroup, "marketGroupID").Nullable(); 
            References(x => x.Graphic, "graphicID").Nullable();
            References(x => x.Icon, "iconID").Nullable();
            References(x => x.Race, "raceID").Nullable();

            HasMany(x => x.Materials).Table("invTypeMaterials").KeyColumn("typeID").AsEntityMap("materialTypeID").Element("quantity", part => part.Type<int>());
            HasMany(x => x.Attributes).KeyColumn("typeID").AsEntityMap("attributeID");
            HasMany(x => x.Effects).Table("dgmTypeEffects").KeyColumn("typeID").AsEntityMap("effectID").Element("isDefault", part => part.Type<bool>());
            HasMany(x => x.ControlTowerResources).KeyColumn("controlTowerTypeID").AsEntityMap("resourceTypeID");
            HasMany(x => x.Installations).Table("ramInstallationTypeContents").KeyColumn("installationTypeID").AsEntityMap("assemblyLineTypeID").Element("quantity", part => part.Type<int>());
                
            Map(x => x.Name, "typeName").Length(100).Nullable();
            Map(x => x.Description, "description").Length(3000).Nullable();
            Map(x => x.Radius, "radius").Nullable();
            Map(x => x.Mass, "mass").Nullable();
            Map(x => x.Volume, "volume").Nullable();
            Map(x => x.Capacity, "capacity").Nullable();
            Map(x => x.PortionSize, "portionSize").Nullable();
            Map(x => x.BasePrice, "basePrice").Nullable();
            Map(x => x.IsPublished, "published").Nullable();
            Map(x => x.ChanceOfDuplicating, "chanceOfDuplicating").Nullable();

        }

    }



    public class InventoryType 
    {
        public InventoryType()
        {
            Materials = new Dictionary<InventoryType, int>();
            Attributes = new Dictionary<DogmaAttributeType, DogmaTypeAttribute>();
            Effects = new Dictionary<DogmaEffect, bool>();
            ControlTowerResources = new Dictionary<InventoryType, ControlTowerResource>();
            Installations = new Dictionary<AssemblyLineType, int>();
        }

        public virtual int Id { get; set; }

        public virtual InventoryGroup Group { get; set; }
        public virtual MarketGroup MarketGroup { get; set; }
        public virtual Graphic Graphic { get; set; }
        public virtual Icon Icon { get; set; }

        public virtual IDictionary<InventoryType, int> Materials { get; set; }
        public virtual IDictionary<DogmaEffect, bool> Effects{ get; set; }
        public virtual IDictionary<DogmaAttributeType, DogmaTypeAttribute> Attributes { get; set; }
        public virtual IDictionary<InventoryType, ControlTowerResource> ControlTowerResources { get; set; }
        public virtual IDictionary<AssemblyLineType, int> Installations { get; set; }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual double Radius { get; set; }
        public virtual double Mass { get; set; }
        public virtual double Volume { get; set; }
        public virtual double Capacity { get; set; }
        public virtual long PortionSize { get; set; }
        public virtual Race Race { get; set; }
        public virtual decimal BasePrice { get; set; }
        public virtual bool IsPublished { get; set; }
        public virtual double ChanceOfDuplicating { get; set; }



        public virtual Image RenderedImage
        {
            get { return ApplicationCore.GetService<EveStaticPictures>().RenderRepository.GetImage(this); }
        }

        public virtual Image GetIcon(PictureSize size)
        {
            return ApplicationCore.GetService<EveStaticPictures>().TypeRepository.GetImage(this,size); 
        }



        public virtual bool Equals(InventoryType other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (InventoryType)) return false;
            return Equals((InventoryType) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", Id, Name);
        }
    }

}