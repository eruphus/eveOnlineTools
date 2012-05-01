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

using FluentNHibernate.Mapping;
using libEveStatic.database.entities.CHR;

namespace libEveStatic.database.entities.INV
{
    /*
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
 
    */


    public class ControlTowerResourceMapper : ClassMap<ControlTowerResource>
    {
        public ControlTowerResourceMapper()
        {
            Table("invControlTowerResources");

            CompositeId().KeyReference(x => x.ResourceType, "resourceTypeID").KeyReference(x => x.ControlTowerType, "controlTowerTypeID");


            References(x => x.Faction, "factionID");
            References(x => x.Purpose, "purpose");

            Map(x => x.Quantity, "quantity");
            Map(x => x.MinSecurityLevel, "minSecurityLevel");
            

        }
    }


    public class ControlTowerResource 
    {
        public virtual InventoryType ResourceType{ get; set; }
        public virtual InventoryType ControlTowerType { get; set; }

        public virtual Faction Faction{ get; set; }
        public virtual ControlTowerResourcePurpose Purpose { get; set; }

        public virtual int Quantity { get; set; }
        public virtual decimal MinSecurityLevel { get; set; }

        public virtual bool Equals(ControlTowerResource other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.ResourceType, ResourceType) && Equals(other.ControlTowerType, ControlTowerType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ControlTowerResource)) return false;
            return Equals((ControlTowerResource) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((ResourceType != null ? ResourceType.GetHashCode() : 0)*397) ^ (ControlTowerType != null ? ControlTowerType.GetHashCode() : 0);
            }
        }
    }
}