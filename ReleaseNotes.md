# Release Notes

## v1.1 (2021-10-26)

### BREAKING CHANGES

* Renamed `ModeInfo` to `DisplayMode`, which affected various classes.
    * `GetModeInfoResponse` --> `GetDisplayModeResponse`
    * `ModeInfoChanged` --> `DisplayModeChanged`
    * `ModeInfoChangedEventArgs` --> `DisplayModeChangedEventArgs`
    * `RadianceProModeInfo` --> `RadianceProDisplayMode`

### Features

* All commands and queries are now logged at the _Debug_ logging level.

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

