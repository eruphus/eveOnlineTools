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

namespace libEveStatic.entities.CHR
{
    /*
    
CREATE TABLE dbo.chrAncestries
(
  ancestryID        tinyint,
  ancestryName      nvarchar(100),
  bloodlineID       tinyint,
  description       nvarchar(1000),
  perception        tinyint,
  willpower         tinyint,
  charisma          tinyint,
  memory            tinyint,
  intelligence      tinyint,
  iconID            int,
  shortDescription  nvarchar(500),

  CONSTRAINT chrAncestries_PK PRIMARY KEY CLUSTERED (ancestryID)
)
    
    *

ALTER TABLE chrAncestries ADD CONSTRAINT chrAncestries_FK_graphic FOREIGN KEY (iconID) REFERENCES eveIcons(iconID)

    */
    public class AncestrieMapper : ClassMap<Ancestrie>
    {
        public AncestrieMapper()
        {
            Table("chrAncestries");

            Id(x => x.Id, "ancestryID");

            References(x => x.Icon, "iconID");
            References(x => x.Bloodline, "bloodlineID");

            Map(x => x.AncestryName, "ancestryName").Length(100);
            Map(x => x.Description, "description").Length(1000);
            Map(x => x.Perception, "perception");
            Map(x => x.Willpower, "willpower");
            Map(x => x.Charisma, "charisma");
            Map(x => x.Memory, "memory");
            Map(x => x.Intelligence, "intelligence");
            Map(x => x.ShortDescription, "shortDescription").Length(500);
            
        }
    }



    public class Ancestrie 
    {
        public virtual int Id { get; set; }

        public virtual Icon Icon { get; set; }
        public virtual Bloodline Bloodline { get; set; }

        public virtual string AncestryName { get; set; }
        public virtual string Description { get; set; }
        public virtual int Perception { get; set; }
        public virtual int Willpower { get; set; }
        public virtual int Charisma { get; set; }
        public virtual int Memory { get; set; }
        public virtual int Intelligence { get; set; }
        public virtual string ShortDescription { get; set; }

    }
}