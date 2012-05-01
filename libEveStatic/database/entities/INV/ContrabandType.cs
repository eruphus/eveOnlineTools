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
     * 
CREATE TABLE dbo.invContrabandTypes
(
  factionID         int,
  typeID            int,

  standingLoss      float,
  confiscateMinSec  float,
  fineByValue       float,
  attackMinSec      float,

  CONSTRAINT invContrabandTypes_PK PRIMARY KEY CLUSTERED (factionID, typeID)
)
  CREATE NONCLUSTERED INDEX invContrabandTypes_IX_type ON dbo.invContrabandTypes (typeID)     * 
     * 
ALTER TABLE invContrabandTypes ADD CONSTRAINT invContrabandTypes_FK_type FOREIGN KEY (typeID) REFERENCES invTypes(typeID)
ALTER TABLE invContrabandTypes ADD CONSTRAINT invContrabandTypes_FK_faction FOREIGN KEY (factionID) REFERENCES chrFactions(factionID)
     * */

    public class ContrabandTypeMapper : ClassMap<ContrabandType>
    {
        public ContrabandTypeMapper()
        {
            Table("invContrabandTypes");

            CompositeId().KeyReference(x => x.Type, "typeID").KeyReference(x => x.Faction, "factionID");


            References(x => x.Faction, "factionID");
            References(x => x.Type, "typeID");

            Map(x => x.StandingLoss, "standingLoss");
            Map(x => x.ConfiscateMinSec, "confiscateMinSec");
            Map(x => x.FineByValue, "fineByValue");
            Map(x => x.AttackMinSec, "attackMinSec");


        }
    }

    public class ContrabandType 
    {
        public virtual InventoryType Type { get; set; }
        public virtual Faction Faction { get; set; }

        public virtual decimal StandingLoss { get; set; }
        public virtual decimal ConfiscateMinSec { get; set; }
        public virtual decimal FineByValue { get; set; }
        public virtual decimal AttackMinSec { get; set; }

        public virtual bool Equals(ContrabandType other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Type, Type) && Equals(other.Faction, Faction);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ContrabandType)) return false;
            return Equals((ContrabandType) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Type != null ? Type.GetHashCode() : 0)*397) ^ (Faction != null ? Faction.GetHashCode() : 0);
            }
        }
    }
}