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
using libEveStatic.database.entities.INV;

namespace libEveStatic.database.entities.CRP
{
    /*
CREATE TABLE dbo.crpNPCCorporationResearchFields
(
  skillID        int,
  corporationID  int,

  CONSTRAINT crpNPCCorporationResearchFields_PK PRIMARY KEY CLUSTERED (skillID, corporationID)
)
     * 
ALTER TABLE crpNPCCorporationResearchFields ADD CONSTRAINT crpNPCCorporationResearchFields_FK_skill FOREIGN KEY (skillID) REFERENCES invTypes(typeID)
ALTER TABLE crpNPCCorporationResearchFields ADD CONSTRAINT crpNPCCorporationResearchFields_FK_corporatioin FOREIGN KEY (corporationID) REFERENCES crpNPCCorporations(corporationID)

    */

    public class NpcCorporationResearchFieldMapper : ClassMap<NpcCorporationResearchField>
    {
        public NpcCorporationResearchFieldMapper()
        {
            Table("crpNPCCorporationResearchFields");

            CompositeId().KeyReference(x => x.Skill, "skillID").KeyReference(x => x.Corporation, "corporationID");

            References(x => x.Skill, "skillID");
            References(x => x.Corporation, "corporationID");

        }
    }


    public class NpcCorporationResearchField 
    {
        public virtual InventoryType Skill { get; set; }
        public virtual NpcCorporation Corporation { get; set; }

        public virtual bool Equals(NpcCorporationResearchField other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Skill, Skill) && Equals(other.Corporation, Corporation);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (NpcCorporationResearchField)) return false;
            return Equals((NpcCorporationResearchField) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Skill != null ? Skill.GetHashCode() : 0)*397) ^ (Corporation != null ? Corporation.GetHashCode() : 0);
            }
        }
    }
}