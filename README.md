# Reddit_41p5yn
Testing an endless runner's camera.

[WebGL link(Recommended)](http://hotrian.com/reddit_41p5yn_webgl/)

[Webplayer link](http://hotrian.com/reddit_41p5yn.html)

Runs great on Win32 and WebGL, though the standard Webplayer has a tiny stutter when you die.

It seems that the Webplayer doesn't zero velocity when colliding before triggering OnCollision, so that there is a slight stutter as the camera doesn't take control until the following frame.

Incase you are unable to load the scene, it consists of only three GameObjects setup as such:

![Player](http://hotrian.com/41p5ynplayer.png)

![Camera](http://hotrian.com/41p5yncamera.png)

![Bounds](http://hotrian.com/41p5ynbounds.png)

Finally, there is a prefab that is setup as such:

![Prefab](http://hotrian.com/41p5ynprefab.png)
