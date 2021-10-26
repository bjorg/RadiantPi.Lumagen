# Release Notes

## v1.1 (TBD)

### BREAKING CHANGES

* Renamed `ModeInfo` to `DisplayMode`, which affected various classes.
    * `GetModeInfoResponse` --> `GetDisplayModeResponse`
    * `ModeInfoChanged` --> `DisplayModeChanged`
    * `ModeInfoChangedEventArgs` --> `DisplayModeChangedEventArgs`
    * `RadianceProModeInfo` --> `RadianceProDisplayMode`

### Fixes

* Consistent application of logging levels
    * Trace: show wire communication
    * Debug: show parsed responses
    * Information: show commands and queries

## v1.0 (2021-10-25)

### Features

* Initial release
* Send commands to a RadiancePro
* Receive events from a RadiancePro

