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
using libEveStatic.database.entities.EVE;

namespace libEveStatic.database.entities.DGM
{

    /*
    CREATE TABLE dbo.dgmEffects
    (
      effectID                        smallint,
     
      durationAttributeID             smallint,
      trackingSpeedAttributeID        smallint,
      dischargeAttributeID            smallint,
      rangeAttributeID                smallint,
      falloffAttributeID              smallint,
      npcUsageChanceAttributeID       smallint,
      npcActivationChanceAttributeID  smallint,
      fittingUsageChanceAttributeID   smallint,
      iconID                          int,

      effectName                      varchar(400) COLLATE Latin1_General_CI_AI,
      effectCategory                  smallint,
      preExpression                   int,
      postExpression                  int,
      description                     varchar(1000),
      guid                            varchar(60),
      isOffensive                     bit,
      isAssistance                    bit,
      disallowAutoRepeat              bit,
      published                       bit,
      displayName                     varchar(100),
      isWarpSafe                      bit,
      rangeChance                     bit,
      electronicChance                bit,
      propulsionChance                bit,
      distribution                    tinyint,
      sfxName                         varchar(20),

      CONSTRAINT dgmEffects_PK PRIMARY KEY CLUSTERED (effectID)
    )
     * 
     * 
     * 
ALTER TABLE dgmEffects ADD CONSTRAINT dgmEffects_FK_durationAttribute FOREIGN KEY (durationAttributeID) REFERENCES dgmAttributeTypes(attributeID)
ALTER TABLE dgmEffects ADD CONSTRAINT dgmEffects_FK_trackingSpeedAttribute FOREIGN KEY (trackingSpeedAttributeID) REFERENCES dgmAttributeTypes(attributeID)
ALTER TABLE dgmEffects ADD CONSTRAINT dgmEffects_FK_dischargeAttribute FOREIGN KEY (dischargeAttributeID) REFERENCES dgmAttributeTypes(attributeID)
ALTER TABLE dgmEffects ADD CONSTRAINT dgmEffects_FK_rangeAttribute FOREIGN KEY (rangeAttributeID) REFERENCES dgmAttributeTypes(attributeID)
ALTER TABLE dgmEffects ADD CONSTRAINT dgmEffects_FK_falloffAttribute FOREIGN KEY (falloffAttributeID) REFERENCES dgmAttributeTypes(attributeID)
ALTER TABLE dgmEffects ADD CONSTRAINT dgmEffects_FK_npcUsageChanceAttributeID FOREIGN KEY (npcUsageChanceAttributeID) REFERENCES dgmAttributeTypes(attributeID)
ALTER TABLE dgmEffects ADD CONSTRAINT dgmEffects_FK_npcActivationChanceAttributeID FOREIGN KEY (npcActivationChanceAttributeID) REFERENCES dgmAttributeTypes(attributeID)
ALTER TABLE dgmEffects ADD CONSTRAINT dgmEffects_FK_fittingUsageChanceAttributeID FOREIGN KEY (fittingUsageChanceAttributeID) REFERENCES dgmAttributeTypes(attributeID)

     * */

    public class DogmaEffectMapper : ClassMap<DogmaEffect>
    {
        public DogmaEffectMapper()
        {
            Table("dgmEffects");

            Id(x => x.Id, "effectID");

            References(x => x.DurationAttributeID, "durationAttributeID");
            References(x => x.TrackingSpeedAttributeID, "trackingSpeedAttributeID");
            References(x => x.DischargeAttributeID, "dischargeAttributeID");
            References(x => x.RangeAttributeID, "rangeAttributeID");
            References(x => x.FalloffAttributeID, "falloffAttributeID");
            References(x => x.NpcUsageChanceAttributeID, "npcUsageChanceAttributeID");
            References(x => x.NpcActivationChanceAttributeID, "npcActivationChanceAttributeID");
            References(x => x.FittingUsageChanceAttributeID, "fittingUsageChanceAttributeID");
            References(x => x.Icon, "iconID");

            Map(x => x.EffectName, "effectName").Length(400);
            Map(x => x.DisplayName, "displayName").Length(100);
            Map(x => x.SfxName, "sfxName").Length(20);
            Map(x => x.Description, "description").Length(1000);
            Map(x => x.Guid, "guid").Length(60);
            Map(x => x.EffectCategory, "effectCategory");
            Map(x => x.PreExpression, "preExpression");
            Map(x => x.PostExpression, "postExpression");
            Map(x => x.IsOffensive, "isOffensive");
            Map(x => x.IsAssistance, "isAssistance");
            Map(x => x.DisallowAutoRepeat, "disallowAutoRepeat");
            Map(x => x.IsPublished, "published");
            Map(x => x.IsWarpSafe, "isWarpSafe");
            Map(x => x.RangeChance, "rangeChance");
            Map(x => x.ElectronicChance, "electronicChance");
            Map(x => x.PropulsionChance, "propulsionChance");
            Map(x => x.Distribution, "distribution");


        }
    }

    public class DogmaEffect 
    {
        public virtual int Id { get; set; }

        public virtual DogmaAttributeType DurationAttributeID { get; set; }
        public virtual DogmaAttributeType TrackingSpeedAttributeID { get; set; }
        public virtual DogmaAttributeType DischargeAttributeID { get; set; }
        public virtual DogmaAttributeType RangeAttributeID { get; set; }
        public virtual DogmaAttributeType FalloffAttributeID { get; set; }
        public virtual DogmaAttributeType NpcUsageChanceAttributeID { get; set; }
        public virtual DogmaAttributeType NpcActivationChanceAttributeID { get; set; }
        public virtual DogmaAttributeType FittingUsageChanceAttributeID { get; set; }
        public virtual Icon Icon { get; set; }


        public virtual string EffectName { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string SfxName { get; set; }
        public virtual string Description { get; set; }
        public virtual string Guid { get; set; }
        public virtual int EffectCategory { get; set; }
        public virtual int PreExpression { get; set; }
        public virtual int PostExpression { get; set; }
        public virtual bool IsOffensive { get; set; }
        public virtual bool IsAssistance { get; set; }
        public virtual bool DisallowAutoRepeat { get; set; }
        public virtual bool IsPublished { get; set; }
        public virtual bool IsWarpSafe { get; set; }
        public virtual bool RangeChance { get; set; }
        public virtual bool ElectronicChance { get; set; }
        public virtual bool PropulsionChance { get; set; }
        public virtual int Distribution { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", Id, EffectName);
        }
    }
}