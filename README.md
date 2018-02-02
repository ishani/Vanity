# Vanity
Static site generator for my photography gallery, [photography.ishani.org](http://photography.ishani.org)

### Features
Vanity accepts an arbitrarily-deep folder hierarchy of images, per-gallery JSON configuration metadata and produces high-quality thumbnails and a set of lean, minified HTML files using T4 templating.

The theme uses Bootstrap 4 and PhotoSwipe to provide a pretty, modern, reactive interface with a focus on the photographs rather than adding too much other cruft.

Vanity uses jpegoptim64.exe to strip and pack resulting JPEGs. It doesn't change any of the input images.

### Modding
While it has some optimisation and caching built in, there's likely a bunch of quirks and bugs in there; I've never really expected others to try and use it for their own work, even though it probably wouldn't be hard to re-theme (3 .tt files)
