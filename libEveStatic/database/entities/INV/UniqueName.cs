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
CREATE TABLE dbo.invUniqueNames
(
  itemID    int                                          NOT NULL,
  itemName  nvarchar(200)  COLLATE Latin1_General_CI_AI  NOT NULL,
  --
  groupID   int                                          NULL,
  --
  CONSTRAINT invUniqueNames_PK PRIMARY KEY CLUSTERED (itemID)
)
CREATE UNIQUE NONCLUSTERED INDEX invUniqueNames_UQ ON dbo.invUniqueNames (itemName)
CREATE NONCLUSTERED INDEX invUniqueNames_IX_GroupName ON dbo.invUniqueNames (groupID, itemName)
     * 
     * 
     * 
ALTER TABLE invUniqueNames ADD CONSTRAINT invUniqueNames_FK_item FOREIGN KEY (itemID) REFERENCES invItems(itemID)
ALTER TABLE invUniqueNames ADD CONSTRAINT invUniqueNames_FK_group FOREIGN KEY (groupID) REFERENCES invGroups(groupID)
    */

    public class UniqueNameMapper : SubclassMap<UniqueName>
    {
        public UniqueNameMapper()
        {
            Table("invUniqueNames");
            
            KeyColumn("itemID");

            References(x => x.Group, "groupID").Nullable();

            Map(x => x.ItemName, "itemName").Length(200).Not.Nullable();
        }
    }

    public class UniqueName : InventoryItem
    {
        public virtual InventoryGroup Group { get; set; }

        public virtual string ItemName { get; set; }
    }
}