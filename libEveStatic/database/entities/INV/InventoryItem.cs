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

namespace libEveStatic.database.entities.INV
{
    /*
CREATE TABLE dbo.invItems
(
    itemID      bigint    NOT NULL,
    typeID      int       NOT NULL,
    ownerID     int       NOT NULL,
    locationID  bigint    NOT NULL,
    flagID      smallint  NOT NULL,
    quantity    int       NOT NULL,  -- Attention! quantity = -1 signifies a non-stackable item with a quantity of 1
                                     -- where as quantity = 1 signifies a stackable item with a quantity of 1
    --
    CONSTRAINT invItems_PK PRIMARY KEY CLUSTERED (itemID)
)
CREATE NONCLUSTERED INDEX items_IX_Location ON invItems (locationID)
CREATE NONCLUSTERED INDEX items_IX_OwnerLocation ON invItems (ownerID, locationID)


    */

    public class InventoryItemMapper : ClassMap<InventoryItem>
    {
        public InventoryItemMapper()
        {
            Table("invItems");
            Id(x => x.Id, "itemID");

            Map(x => x.TypeId, "typeID").Not.Nullable();
            Map(x => x.OwnerId, "ownerID").Not.Nullable();
            Map(x => x.LocationId, "locationID").Not.Nullable();
            Map(x => x.FlagId, "flagID").Not.Nullable();
            Map(x => x.Quantity, "quantity").Not.Nullable();
        }

    }


    public class InventoryItem 
    {
        public virtual long Id { get; set; }
        public virtual int TypeId { get; set; }
        public virtual int OwnerId { get; set; }
        public virtual long LocationId { get; set; }
        public virtual int FlagId { get; set; }
        public virtual int Quantity { get; set; }

        public virtual bool IsStackable { get { return Quantity > 0; } }
    }
}