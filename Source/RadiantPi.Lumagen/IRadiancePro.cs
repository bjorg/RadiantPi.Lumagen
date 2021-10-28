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

using System;
using System.Threading.Tasks;
using RadiantPi.Lumagen.Model;

namespace RadiantPi.Lumagen {

    public class DisplayModeChangedEventArgs : EventArgs {

        //--- Constructors ---
        public DisplayModeChangedEventArgs(RadianceProDisplayMode displayMode)
            => DisplayMode = displayMode ?? throw new ArgumentNullException(nameof(displayMode));

        //--- Properties ---
        public RadianceProDisplayMode DisplayMode { get; }
    }

    public interface IRadiancePro : IDisposable {

        //--- Events ---

        /// <summary>
        /// Event triggered when the display mode changes.
        /// </summary>
        event EventHandler<DisplayModeChangedEventArgs> DisplayModeChanged;

        //--- Methods ---

        /// <summary>
        /// Get information about the device, such as model name and serial number.
        /// </summary>
        /// <returns>Device information</returns>
        Task<GetDeviceInfoResponse> GetDeviceInfoAsync();

        /// <summary>
        /// Get information about the current display mode, such as resolution, aspect ratio, etc.
        /// </summary>
        /// <returns>Display mode information</returns>
        Task<GetDisplayModeResponse> GetDisplayModeAsync();

        /// <summary>
        /// Select a memory to be active.
        /// </summary>
        /// <param name="memory">Memory A through D</param>
        Task SelectMemoryAsync(RadianceProMemory memory);

        /// <summary>
        /// Show a message with up to 2 lines of 30 characters.
        /// </summary>
        /// <param name="message">Message to show. Max 60 characters in range from ' ' (space) to 'z'</param>
        /// <param name="delay">Length to display. 2 seconds + 5 * delay. 9 shows message until cleared.</param>
        Task ShowMessageAsync(string message, int delay);

        /// <summary>
        /// Clear a message.
        /// </summary>
        Task ClearMessageAsync();

        /// <summary>
        /// Send a command.
        /// </summary>
        /// <param name="command">RadiancePro command</param>
        Task SendAsync(string command);

        /// <summary>
        /// Send a query command that expects a response.
        /// </summary>
        /// <param name="command">RadiancePro query command</param>
        /// <returns>Response value</returns>
        Task<string> QueryAsync(string command);

        /// <summary>
        /// Get the label for an input by memory.
        /// </summary>
        /// <param name="memory">Memory A through D</param>
        /// <param name="input">Input 1 through 10</param>
        /// <returns>Label value</returns>
        Task<string> GetInputLabelAsync(RadianceProMemory memory, RadianceProInput input);

        /// <summary>
        /// Set the label of an input by memory.
        /// </summary>
        /// <param name="memory">Memory A through D or All</param>
        /// <param name="input">Input 1 through 10</param>
        /// <param name="value">Label value. Max 10 characters</param>
        Task SetInputLabelAsync(RadianceProMemory memory, RadianceProInput input, string value);

        /// <summary>
        /// Get the label for a custom mode.
        /// </summary>
        /// <param name="customMode">Custom Mode 0 through 7</param>
        /// <returns>Label value</returns>
        Task<string> GetCustomModeLabelAsync(RadianceProCustomMode customMode);

        /// <summary>
        /// Set the label for a custom mode.
        /// </summary>
        /// <param name="customMode">Custom Mode 0 through 7</param>
        /// <param name="value">Label value</param>
        Task SetCustomModeLabelAsync(RadianceProCustomMode customMode, string value);

        /// <summary>
        /// Get the label for a CMS entry.
        /// </summary>
        /// <param name="cms">CMS 0 through 7</param>
        /// <returns>Label value</returns>
        Task<string> GetCmsLabelAsync(RadianceProCms cms);

        /// <summary>
        /// Set the label for a CMS entry.
        /// </summary>
        /// <param name="cms">CMS 0 through 7</param>
        /// <param name="value">Label value</param>
        Task SetCmsLabelAsync(RadianceProCms cms, string value);

        /// <summary>
        /// Get the label for a style entry.
        /// </summary>
        /// <param name="style">Style 0 through 7</param>
        /// <returns>Label value</returns>
        Task<string> GetStyleLabelAsync(RadianceProStyle style);

        /// <summary>
        /// Set the label for a style entry.
        /// </summary>
        /// <param name="style">Style 0 through 7</param>
        /// <param name="value">Label value</param>
        Task SetStyleLabelAsync(RadianceProStyle style, string value);
    }
}
