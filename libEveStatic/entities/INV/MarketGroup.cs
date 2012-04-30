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
CREATE TABLE dbo.invMarketGroups
(
  marketGroupID    smallint,
  --
  parentGroupID    smallint,
  marketGroupName  nvarchar(100),
  description      nvarchar(3000),
  iconID           int,
  hasTypes         bit,

  CONSTRAINT invMarketGroups_PK PRIMARY KEY CLUSTERED (marketGroupID)
)			
 
ALTER TABLE invMarketGroups ADD CONSTRAINT invMarketGroups_FK_parentGroup FOREIGN KEY (parentGroupID) REFERENCES invMarketGroups(marketGroupID)
ALTER TABLE invMarketGroups ADD CONSTRAINT invMarketGroups_FK_graphic FOREIGN KEY (iconID) REFERENCES eveIcons(iconID)

    */


    public class InventoryMarketGroupMapper : ClassMap<MarketGroup>
    {

        public InventoryMarketGroupMapper()
        {
            Table("invMarketGroups");
            Id(x => x.MarketGroupId, "marketGroupID");

            References(x => x.ParentGroup, "parentGroupID");
            References(x => x.Icon, "iconID");

            HasMany(x => x.ChildGrups).KeyColumn("parentGroupID").Not.KeyNullable().Cascade.None().AsBag().Not.Inverse();

            Map(x => x.Name, "marketGroupName").Length(100).Nullable();
            Map(x => x.Description, "description").Length(3000).Nullable();
            Map(x => x.HasTypes, "hasTypes").Nullable();

        }

    }

    public class MarketGroup 
    {

        public MarketGroup()
        {
            ChildGrups = new List<MarketGroup>();
        }

        public virtual IList<MarketGroup> ChildGrups { get; set; }

        public virtual MarketGroup ParentGroup { get; set; }
        public virtual int MarketGroupId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Icon Icon { get; set; }
        public virtual bool HasTypes { get; set; }
    }
}