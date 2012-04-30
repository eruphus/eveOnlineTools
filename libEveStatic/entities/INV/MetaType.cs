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

namespace libEveStatic.entities.INV
{

    /*
CREATE TABLE dbo.invMetaTypes
(
  typeID        int,
  --
  parentTypeID  int,
  metaGroupID   smallint,

  CONSTRAINT invMetaTypes_PK PRIMARY KEY CLUSTERED(typeID)
)


ALTER TABLE invMetaTypes ADD CONSTRAINT invMetaTypes_FK_type FOREIGN KEY (typeID) REFERENCES invTypes(typeID)
ALTER TABLE invMetaTypes ADD CONSTRAINT invMetaTypes_FK_parentType FOREIGN KEY (parentTypeID) REFERENCES invTypes(typeID)
ALTER TABLE invMetaTypes ADD CONSTRAINT invMetaTypes_FK_metaGroup FOREIGN KEY (metaGroupID) REFERENCES invMetaGroups(metaGroupID)

 
     * 
     */

    public class MetaTypeMapper : SubclassMap<MetaType>
    {
        public MetaTypeMapper()
        {
            Table("invMetaTypes");
            KeyColumn("typeID");

            References(x => x.Parent, "parentTypeID");
            References(x => x.MetaGroup, "metaGroupID");

        }
    }


    public class MetaType : InventoryType
    {

        public virtual InventoryType Parent { get; set; }
        public virtual MetaGroup MetaGroup { get; set; }

    }
}