/*
 * RadiantPi.Lumagen - Communication client for Lumagen RadiancePro
 * Copyright (C) 2020-2021 - Steve G. Bjorg
 *
 * This program is free software: you can redistribute it and/or modify it
 * under the terms of the GNU Affero General Public License as published by the
 * Free Software Foundation, either version 3 of the License, or (at your option)
 * any later version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU Affero General Public License for more
 * details.
 *
 * You should have received a copy of the GNU Affero General Public License along
 * with this program. If not, see <https://www.gnu.org/licenses/>.
 */

namespace RadiantPi.Lumagen.Model {

    public sealed class GetDeviceInfoResponse {

        // Returns model name, software revision, model#, serial #.
        // Example response: "!S01,RadianceXD,102308,1009,745<CR><LF>".
        // Radiance XD model number is 1009, XE is 1010, XS is 1011, Mini is 1014, 20XX is 1016, 21XX is 1017, all Pro are 1018.

        //--- Constructors ---
        public GetDeviceInfoResponse(string modelName, string softwareRevision, string modelNumber, string serialNumber) {
            ModelName = modelName ?? throw new System.ArgumentNullException(nameof(modelName));
            SoftwareRevision = softwareRevision ?? throw new System.ArgumentNullException(nameof(softwareRevision));
            ModelNumber = modelNumber ?? throw new System.ArgumentNullException(nameof(modelNumber));
            SerialNumber = serialNumber ?? throw new System.ArgumentNullException(nameof(serialNumber));
        }

        //--- Properties ---
        public string ModelName { get; }
        public string SoftwareRevision { get; }
        public string ModelNumber { get; }
        public string SerialNumber { get; }
    }
}
