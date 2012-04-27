/*
    Copyright 2012 Alexander W�lfel 
 
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

    EveStatic ist Freie Software: Sie k�nnen es unter den Bedingungen
    der GNU General Public License, wie von der Free Software Foundation,
    Version 3 der Lizenz weiterverbreiten und/oder modifizieren.

    EveStatic wird in der Hoffnung, dass es n�tzlich sein wird, aber
    OHNE JEDE GEW�HELEISTUNG, bereitgestellt; sogar ohne die implizite
    Gew�hrleistung der MARKTF�HIGKEIT oder EIGNUNG F�R EINEN BESTIMMTEN ZWECK.
    Siehe die GNU General Public License f�r weitere Details.

    Sie sollten eine Kopie der GNU General Public License zusammen mit diesem
    Programm erhalten haben. Wenn nicht, siehe <http://www.gnu.org/licenses/>. 
 
 */

using FluentNHibernate.Mapping;

namespace eveStatic.entities.EVE
{
    /*
CREATE TABLE dbo.eveIcons
(
  iconID         int            NOT NULL,
  iconFile       varchar(500)   NOT NULL  DEFAULT '',
  [description]  nvarchar(max)  NOT NULL  DEFAULT '', [16000]
  
  CONSTRAINT eveIcons_PK PRIMARY KEY CLUSTERED (iconID)
)		
    */


    public class IconMapper : ClassMap<Icon>
    {

        public IconMapper()
        {
            Table("eveIcons");
            Id(x => x.Id, "iconID");

            Map(x => x.File, "iconFile").Length(100).Not.Nullable();
            Map(x => x.Description, "description").Length(16000).Not.Nullable();
        }

    }

    public class Icon 
    {

        public virtual int Id { get; set; }

        public virtual string File { get; set; }
        public virtual string Description { get; set; }
    }
}