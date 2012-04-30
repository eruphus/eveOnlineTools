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

namespace libEveStatic.entities.EVE
{
    /*
CREATE TABLE dbo.eveGraphics
(
  graphicID          int            NOT NULL,
  graphicFile        varchar(500)   NOT NULL  DEFAULT '',
  [description]      nvarchar(max)  NOT NULL  DEFAULT '',  [16000]
  obsolete           bit            NOT NULL  DEFAULT 0,
  graphicType        varchar(100)   NULL,
  collidable         bit            NULL,
  explosionID        int            NULL,
  directoryID        int            NULL,
  graphicName        nvarchar(64)   NOT NULL  DEFAULT '',
  
  CONSTRAINT eveGraphics_PK PRIMARY KEY CLUSTERED (graphicID)
)

   
*/


    public class GraphicMapper : ClassMap<Graphic>
    {

        public GraphicMapper()
        {
            Table("eveGraphics");
            Id(x => x.Id, "graphicID");

            Map(x => x.Name, "graphicName").Length(64).Not.Nullable();
            Map(x => x.Description, "description").Length(16000).Not.Nullable();
            Map(x => x.File, "graphicFile").Length(500).Not.Nullable();
            Map(x => x.IsObsolete, "obsolete").Not.Nullable();

            Map(x => x.Type, "graphicType").Length(100).Nullable();
            Map(x => x.IsCollidable, "collidable").Nullable();
            Map(x => x.ExplosionId, "explosionID").Nullable();
            Map(x => x.DirectoryId, "directoryID").Nullable();
        }

    }

    public class Graphic 
    {
        public virtual int Id { get; set; }

        public virtual string File { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsObsolete { get; set; }
        public virtual string Name { get; set; }

        public virtual bool IsCollidable { get; set; }
        public virtual int ExplosionId { get; set; }
        public virtual int DirectoryId { get; set; }
        public virtual string Type { get; set; }
    }
}