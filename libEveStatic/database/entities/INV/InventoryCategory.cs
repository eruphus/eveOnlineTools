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
using FluentNHibernate.Mapping;
using libEveStatic.database.entities.EVE;

namespace libEveStatic.database.entities.INV
{
    /*
CREATE TABLE dbo.invCategories
(
  categoryID    int,
 
  categoryName  nvarchar(100)   COLLATE Latin1_General_CI_AI,
  description   nvarchar(3000),
  iconID        int,
  published     bit,

  CONSTRAINT invCategories_PK PRIMARY KEY CLUSTERED (categoryID)
)
		
ALTER TABLE invCategories ADD CONSTRAINT invCategories_FK_graphic FOREIGN KEY (iconID) REFERENCES eveIcons(iconID)
    */


    public class InventoryCategoryMapper : ClassMap<InventoryCategory>
    {

        public InventoryCategoryMapper()
        {
            Table("invCategories");
            Id(x => x.Id, "categoryID");

            References(x => x.Icon, "iconID").Nullable();
            HasMany(x => x.Groups).KeyColumn("categoryID").Not.KeyNullable().Cascade.None().AsBag().Not.Inverse();
            
            Map(x => x.Name, "categoryName").Length(100).Nullable();
            Map(x => x.Description, "description").Length(3000).Nullable();
            Map(x => x.IsPublished, "published").Nullable();
        
        }

    }

    public class InventoryCategory 
    {
        public InventoryCategory()
        {
            Groups = new List<InventoryGroup>();
        }
        public virtual int Id { get; set; }

        public virtual Icon Icon { get; set; }

        public virtual IList<InventoryGroup> Groups { get; set; }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsPublished { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", Id, Name);
        }
    }
}