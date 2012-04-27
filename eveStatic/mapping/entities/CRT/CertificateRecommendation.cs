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
using eveStatic.entities.CRP;
using eveStatic.entities.EVE;
using eveStatic.entities.INV;

namespace eveStatic.entities.CRT
{
    /*
    
CREATE TABLE dbo.crtRecommendations
(
  recommendationID      int       NOT NULL,
  shipTypeID            int       NULL,
  certificateID         int       NULL,
  recommendationLevel   tinyint   NOT NULL DEFAULT(0),
  
  CONSTRAINT crtRecommendations_PK PRIMARY KEY CLUSTERED (recommendationID)
)
CREATE NONCLUSTERED INDEX crtRecommendations_IX_shipType ON crtRecommendations (shipTypeID)
CREATE NONCLUSTERED INDEX crtRecommendations_IX_certificate ON crtRecommendations (certificateID)
GO
     * 
ALTER TABLE dbo.crtRecommendations ADD CONSTRAINT crtRecommendations_FK_shipType FOREIGN KEY (shipTypeID) REFERENCES dbo.invTypes(typeID)
ALTER TABLE dbo.crtRecommendations ADD CONSTRAINT crtRecommendations_FK_certificate FOREIGN KEY (certificateID) REFERENCES dbo.crtCertificates(certificateID)
     */


    public class CertificateRecommendationMapper : ClassMap<CertificateRecommendation>
    {
        public CertificateRecommendationMapper()
        {
            Table("crtRecommendations");

            Id(x => x.Id, "recommendationID");

            References(x => x.Ship, "shipTypeID").Nullable();
            References(x => x.Certificate, "certificateID").Nullable();

            Map(x => x.RecommendationLevel, "recommendationLevel").Not.Nullable();
        }
    }


    public class CertificateRecommendation 
    {
        public virtual int Id { get; set; }

        public virtual InventoryType Ship { get; set; }
        public virtual Certificate Certificate { get; set; }
        public virtual int RecommendationLevel { get; set; }

    }
}