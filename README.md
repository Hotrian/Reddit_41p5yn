# Reddit_41p5yn Alternate Implementation
Testing an endless runner's camera.
This version does not follow the player up and down as they jump

[WebGL link(Recommended)](http://hotrian.com/reddit_41p5yn_webgl_alternate/)

Runs great on Win32 and WebGL, though the standard Webplayer has a tiny stutter when you die.

It seems that the Webplayer doesn't zero velocity when colliding before triggering OnCollision, so that there is a slight stutter as the camera doesn't take control until the following frame.
