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
using libEveStatic.database.entities.CRP;
using libEveStatic.database.entities.EVE;

namespace libEveStatic.database.entities.CRT
{
    /*


CREATE TABLE dbo.crtCertificates
(
  certificateID       int,
     * 
  categoryID          tinyint,
  classID             int,
  grade               tinyint,
  corpID              int,
  iconID              int,
  description         nvarchar(500),

  CONSTRAINT crtCertificates_PK PRIMARY KEY CLUSTERED (certificateID)
)
CREATE NONCLUSTERED INDEX crtCertificates_IX_category ON dbo.crtCertificates(categoryID)
CREATE NONCLUSTERED INDEX crtCertificates_IX_class ON dbo.crtCertificates(classID)

     * 
ALTER TABLE dbo.crtCertificates ADD CONSTRAINT crtCertificates_FK_category FOREIGN KEY (categoryID) REFERENCES crtCategories(categoryID)
ALTER TABLE dbo.crtCertificates ADD CONSTRAINT crtCertificates_FK_class FOREIGN KEY (classID) REFERENCES crtClasses(classID)
ALTER TABLE dbo.crtCertificates ADD CONSTRAINT crtCertificates_FK_corp FOREIGN KEY (corpID) REFERENCES dbo.crpNPCCorporations(corporationID)

     * */

    public class CertificateMapper : ClassMap<Certificate>
    {
        public CertificateMapper()
        {
            Table("crtCertificates");

            Id(x => x.Id, "certificateID");

            References(x => x.Category, "categoryID").Nullable();
            References(x => x.Class, "classID").Nullable();
            References(x => x.Corp, "corpID").Nullable();
            References(x => x.Icon, "iconID").Nullable();

            Map(x => x.Grade, "grade").Nullable();
            Map(x => x.Description, "description").Nullable().Length(500);
        }
    }

    public class Certificate 
    {
        public virtual int Id { get; set; }

        public virtual CertificateCategory Category { get; set; }
        public virtual CertificateClass Class { get; set; }
        public virtual NpcCorporation Corp { get; set; }
        public virtual Icon Icon { get; set; }

        public virtual int Grade  { get; set; }
        public virtual string Description { get; set; }

    }
}