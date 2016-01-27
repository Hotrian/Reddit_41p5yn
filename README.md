# Reddit_41p5yn
Testing an endless runner's camera.

Runs great on Win32 but needs a slight fix for web if you mind that tiny stutter when you die.

It seems that the Webplayer doesn't zero velocity when colliding before triggering OnCollision, so that there is a slight stutter as the camera doesn't take control until the following frame.

Incase you are unable to load the scene, it consists of only three GameObjects setup as such:

![Player](http://hotrian.com/41p5ynplayer.png)

![Camera](http://hotrian.com/41p5yncamera.png)

![Bounds](http://hotrian.com/41p5ynbounds.png)

Finally, there is a prefab that is setup as such:

![Prefab](http://hotrian.com/41p5ynprefab.png)
