# TO DO

## Commands to Add

<dl>

<dt><c>ZY0M7&lt;CR&gt;</c></dt>
<dd>

Set zoom factor to M: Where M can be 0-2 (or 0-7 if zoom is set for 5% steps)

</dd>

<dt><c>ZY2MMMNNNOOOPPP&lt;CR&gt;</c></dt>
<dd>

Set output shrink parameters: MMM=top, NNN=left, OOO=bottom, PPP=right edge. Range is 0-255 for each.

</dd>

<dt><c>ZQO03</c></dt>
<dd>

Output shrink: Returns (top,left,bottom,right) 000-255 pixels (decimal)

</dd>

<dt><c>ZY418CRRGGBB&lt;CR&gt;</c></dt>
<dd>

Set RS232 message command colors and transparency (Radiance Pro only)—C=0,1,2.

A 0=sets background color. 1=sets foreground color. 2=sets blend value.

RRGGBB for foreground, background id RGB color were RR, GG, or BB is hexadecimal 00-ff (0-256) value.
When setting blend value, only last B digit is used so range is 000001-00000f where 'f'isopaque messages and '1'is near transparent.

</dd>

## Logging

Always capitalize messages.

* Use Trace for
    * protocol communication
* Use Debug for
    * actions NOT taken
    * additional details not included in LogInformation
    * serialized data structures
* Use Info for
    * action taken
* Use Warn for
    * incomplete information and recoverable, unexpected situations
* Use Error for
    * unexpected situations that cause an operation to fail
* Use Critical for
    * unexpected situations that cause the application to exit
