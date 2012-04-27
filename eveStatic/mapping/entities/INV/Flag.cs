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

namespace eveStatic.entities.INV
{

    /*
     * 
CREATE TABLE dbo.invFlags
(
  flagID    smallint,
  flagName  varchar(200),
  flagText  varchar(100),
  orderID   int,

  CONSTRAINT invFlags_PK PRIMARY KEY CLUSTERED (flagID)
)
 
     * 
     * */
    public class FlagMapper : ClassMap<Flag>
    {
        public FlagMapper()
        {
            Table("invFlags");
            

            Id(x => x.Id, "flagID");

            Map(x => x.FlagName, "flagName").Length(200);
            Map(x => x.FlagText, "flagText").Length(100);
            Map(x => x.OrderId, "orderID");

        }
    }

    public class Flag 
    {
        public virtual long Id { get; set; }

        public virtual string FlagName { get; set; }
        public virtual string FlagText { get; set; }
        public virtual int OrderId { get; set; }
    }
}