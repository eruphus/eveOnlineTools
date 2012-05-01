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
using libEveStatic.database.entities.INV;

namespace libEveStatic.database.entities.CRT
{
    /*
-- Certificate relationships
-- ParentID = Required certificateID
-- ParentTypeID = Required skill typeID
  -- parentLevel = Level of skill (parentTypeID) required
-- childID = CertificateID of certificates requiring this certificate
     * 
CREATE TABLE dbo.crtRelationships
(
  relationshipID    int,
  parentID          int,
  parentTypeID      int,
  parentLevel       tinyint,
  childID           int,

  CONSTRAINT crtRelationships_relationship PRIMARY KEY CLUSTERED (relationshipID)
)
CREATE NONCLUSTERED INDEX crtRelationships_IX_parent ON dbo.crtRelationships(parentID)
CREATE NONCLUSTERED INDEX crtRelationships_IX_child ON dbo.crtRelationships(childID)

     * 
ALTER TABLE dbo.crtRelationships ADD CONSTRAINT crtRelationships_FK_child  FOREIGN KEY (childID) REFERENCES dbo.crtCertificates(certificateID)

     * 
     */
    public class CertificateRelationshipMapper : ClassMap<CertificateRelationship>
    {
        public CertificateRelationshipMapper()
        {
            Table("crtRelationships");

            Id(x => x.Id, "relationshipID");

            References(x => x.Parent, "parentID").Nullable();
            References(x => x.Child, "childID").Nullable();
            References(x => x.ParentType, "parentTypeID").Nullable();

            Map(x => x.ParentLevel, "parentLevel").Nullable();
        }
    }
    public class CertificateRelationship 
    {
        public virtual int Id { get; set; }

        public virtual Certificate Parent { get; set; }
        public virtual Certificate Child { get; set; }
        public virtual InventoryType ParentType { get; set; }

        public virtual int ParentLevel { get; set; }

    }
}