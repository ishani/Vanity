# Vanity

After many years of hosting photography on 3rd party sites, subject to their cluttered designs, overbearing social mechanisms and occasionally questionable licences - I decided to go it alone and host my own work with no mess, no distractions. 

Vanity produces a lean, compact, static website where the focus is solely on the images.

I use it for my own gallery, [photography.ishani.org](http://photography.ishani.org), but it wouldn't be difficult to bend into another shape should you want to use it for your own.

![Demo image 1](https://raw.githubusercontent.com/ishani/Vanity/master/doc/vanity_1.jpg)

## Features
Vanity accepts an arbitrarily-deep folder hierarchy of images, per-gallery JSON configuration metadata and produces high-quality thumbnails and a set of minified HTML files using T4 templating.

![Demo image 2](https://raw.githubusercontent.com/ishani/Vanity/master/doc/vanity_2.jpg)

The theme uses Bootstrap 4 and [PhotoSwipe](https://github.com/dimsemenov/PhotoSwipe) to provide a minimalist interface that works on any device.

Vanity uses _jpegoptim64_ to strip and pack resulting JPEGs. It doesn't change any of the input images.

## Modding
It's somewhat optimised (doesn't do work if it can avoid it) and pretty well tested (in use for over 3 years now) but YMMV - to customize it, you can fiddle with the 3 T4 files and single stylesheet fairly easily.