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

CREATE TABLE dbo.crpNPCCorporationTrades
(
  corporationID  int,
  typeID         int,
  
  CONSTRAINT crpNPCCorporationTrades_PK PRIMARY KEY CLUSTERED (corporationID, typeID)
)

ALTER TABLE dbo.crpNPCCorporationTrades ADD CONSTRAINT crpNPCCorporationTrades_FK_corporation FOREIGN KEY (corporationID) REFERENCES dbo.crpNPCCorporations(corporationID)
ALTER TABLE dbo.crpNPCCorporationTrades ADD CONSTRAINT crpNPCCorporationTrades_FK_type FOREIGN KEY (typeID) REFERENCES dbo.invTypes(typeID)

    */

    public class NpcCorporationTradeMapper : ClassMap<NpcCorporationTrade>
    {
        public NpcCorporationTradeMapper()
        {
            Table("crpNPCCorporationTrades");

            CompositeId().KeyReference(x => x.Type, "typeID").KeyReference(x => x.Corporation, "corporationID");

            References(x => x.Type, "typeID");
            References(x => x.Corporation, "corporationID");

        }
    }


    public class NpcCorporationTrade
    {
     
        public virtual InventoryType Type { get; set; }
        public virtual NpcCorporation Corporation { get; set; }

        public virtual  bool Equals(NpcCorporationTrade other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Type, Type) && Equals(other.Corporation, Corporation);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (NpcCorporationTrade)) return false;
            return Equals((NpcCorporationTrade) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Type != null ? Type.GetHashCode() : 0)*397) ^ (Corporation != null ? Corporation.GetHashCode() : 0);
            }
        }
    }
    
}