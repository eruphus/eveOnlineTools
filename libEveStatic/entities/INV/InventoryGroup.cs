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
using libEveStatic.entities.EVE;

namespace libEveStatic.entities.INV
{
    /*
CREATE TABLE dbo.invGroups
(
  groupID               int,
  --
  categoryID            int,
  groupName             nvarchar(100)   COLLATE Latin1_General_CI_AI,
  description           nvarchar(3000),
  iconID                int,
  useBasePrice          bit,
  allowManufacture      bit,
  allowRecycler         bit,
  anchored              bit,
  anchorable            bit,
  fittableNonSingleton  bit,
  published             bit,
  
  CONSTRAINT invGroups_PK PRIMARY KEY CLUSTERED (groupID)
)
  CREATE NONCLUSTERED INDEX invGroups_IX_category ON dbo.invGroups (categoryID)		
     * 

ALTER TABLE invGroups ADD CONSTRAINT invGroups_FK_category FOREIGN KEY (categoryID) REFERENCES invCategories(categoryID)
ALTER TABLE invGroups ADD CONSTRAINT invGroups_FK_graphic FOREIGN KEY (iconID) REFERENCES eveIcons(iconID)

     */


    public class InventoryGroupMapper : ClassMap<InventoryGroup>
    {

        public InventoryGroupMapper()
        {
            Table("invGroups");
            Id(x => x.Id, "groupID");

            References(x => x.Icon, "iconID");
            References(x => x.Category, "categoryID");

            HasMany(x => x.InventoryTypes).KeyColumn("groupID").Not.KeyNullable().Cascade.None().AsBag().Not.Inverse();


            Map(x => x.Name, "groupName").Length(100).Nullable();
            Map(x => x.Description, "description").Length(3000).Nullable();
            Map(x => x.UseBasePrice, "useBasePrice").Nullable();
            Map(x => x.AllowManufacture, "allowManufacture").Nullable();
            Map(x => x.AllowRecycler, "allowRecycler").Nullable();
            Map(x => x.Anchored, "anchored").Nullable();
            Map(x => x.Anchorable, "anchorable").Nullable();
            Map(x => x.FittableNonSingleTon, "fittableNonSingleton").Nullable();
            Map(x => x.Published, "published").Nullable();
        }

    }

    public class InventoryGroup 
    {
        public InventoryGroup()
        {
            InventoryTypes = new List<InventoryType>();
        }

        public virtual int Id { get; set; }
        
        public virtual InventoryCategory Category { get; set; }
        public virtual Icon Icon { get; set; }

        public virtual IList<InventoryType> InventoryTypes { get; set; }
        
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool UseBasePrice { get; set; }
        public virtual bool AllowManufacture { get; set; }
        public virtual bool AllowRecycler { get; set; }
        public virtual bool Anchored { get; set; }
        public virtual bool Anchorable { get; set; }
        public virtual bool FittableNonSingleTon { get; set; }
        public virtual bool Published { get; set; }

        public override string ToString()
        {
            return string.Format("[{0}] {1}", Id, Name);
        }
    }
}