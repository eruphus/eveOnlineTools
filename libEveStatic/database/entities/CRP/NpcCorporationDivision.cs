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

namespace libEveStatic.database.entities.CRP
{

    /*

CREATE TABLE dbo.crpNPCCorporationDivisions
(
  corporationID   int,
  divisionID      tinyint,
  [size]          tinyint,

  CONSTRAINT crpNPCCorporationDivisions_PK PRIMARY KEY CLUSTERED (corporationID, divisionID)
)
     * 
     * 
ALTER TABLE crpNPCCorporationDivisions ADD CONSTRAINT crpNPCCorporationDivisions_FK_corporation FOREIGN KEY (corporationID) REFERENCES crpNPCCorporations(corporationID)
ALTER TABLE crpNPCCorporationDivisions ADD CONSTRAINT crpNPCCorporationDivisions_FK_division FOREIGN KEY (divisionID) REFERENCES crpNPCDivisions(divisionID)
    */


    public class NpcCorporationDivisionMapper : ClassMap<NpcCorporationDivision>
    {
        public NpcCorporationDivisionMapper()
        {
            Table("crpNPCCorporationDivisions");

            CompositeId().KeyReference(x => x.NpcDevision, "divisionID").KeyReference(x => x.Corporation, "corporationID");

            References(x => x.NpcDevision, "divisionID");
            References(x => x.Corporation, "corporationID");

            Map(x => x.Size, "size");

        }
    }

    public class NpcCorporationDivision 
    {
        public virtual NpcDevision NpcDevision { get; set; }
        public virtual NpcCorporation Corporation { get; set; }

        public virtual int Size { get; set; }

        public virtual bool Equals(NpcCorporationDivision other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.NpcDevision, NpcDevision) && Equals(other.Corporation, Corporation);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (NpcCorporationDivision)) return false;
            return Equals((NpcCorporationDivision) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((NpcDevision != null ? NpcDevision.GetHashCode() : 0)*397) ^ (Corporation != null ? Corporation.GetHashCode() : 0);
            }
        }
    }
}