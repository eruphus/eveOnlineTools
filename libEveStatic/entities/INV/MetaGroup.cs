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
using libEveStatic.entities.EVE;

namespace libEveStatic.entities.INV
{
    /*

CREATE TABLE dbo.invMetaGroups
(
  metaGroupID    smallint,
  --
  metaGroupName  nvarchar(100),
  description    nvarchar(1000),
  iconID         int,

  CONSTRAINT invMetaGroups_PK PRIMARY KEY CLUSTERED (metaGroupID)
)

     * 
     * 
ALTER TABLE invMetaGroups ADD CONSTRAINT invMetaGroups_FK_graphic FOREIGN KEY (iconID) REFERENCES eveIcons(iconID)

    */

    public class MetaGroupMapper : ClassMap<MetaGroup>
    {
        public MetaGroupMapper()
        {
            Table("invMetaGroups");

            Id(x => x.Id, "metaGroupID");

            References(x => x.Icon, "iconId");

            Map(x => x.MetaGroupName, "metaGroupName").Length(100);
            Map(x => x.Description, "description").Length(1000);
        }
    }


    public class MetaGroup 
    {
        public virtual int Id { get; set; }

        public virtual Icon Icon { get; set; }

        public virtual string MetaGroupName { get; set; }
        public virtual string Description { get; set; }
        
    }
}