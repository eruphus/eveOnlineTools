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
using libEveStatic.database.entities.EVE;

namespace libEveStatic.database.entities.CHR
{
    /*

CREATE TABLE dbo.chrAttributes
(
  attributeID       tinyint,
  attributeName     varchar(100),
  description       varchar(1000),
  iconID            int,
  shortDescription  nvarchar(500),
  notes             nvarchar(500),

  CONSTRAINT chrAttributes_PK PRIMARY KEY CLUSTERED (attributeID)
)

ALTER TABLE chrAttributes ADD CONSTRAINT chrAttributes_FK_graphic FOREIGN KEY (iconID) REFERENCES eveIcons(iconID)

    */


    public class AttributeMapper : ClassMap<Attribute>
    {
        public AttributeMapper()
        {
            Table("chrAttributes");

            Id(x => x.Id, "attributeID");

            References(x => x.Icon, "iconID");

            Map(x => x.AttributeName, "attributeName").Length(100);
            Map(x => x.Description, "description").Length(1000);
            Map(x => x.ShortDescription, "shortDescription").Length(500);
            Map(x => x.Notes, "notes").Length(500);

        }
    }

    public class Attribute 
    {
        public virtual int Id { get; set; }

        public virtual Icon Icon { get; set; }

        public virtual string AttributeName { get; set; }
        public virtual string Description { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual string Notes { get; set; }

    }
}