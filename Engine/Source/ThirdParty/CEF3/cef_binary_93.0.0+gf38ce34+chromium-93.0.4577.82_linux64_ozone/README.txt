Chromium Embedded Framework (CEF) Standard Binary Distribution for Linux
-------------------------------------------------------------------------------

Date:             September 29, 2022

CEF Version:      93.0.0+gf38ce34+chromium-93.0.4577.82
CEF URL:          https://bitbucket.org/chromiumembedded/cef.git
                  @f38ce3409c5cfc5dcadbf1e219ffaaf7e720b609

Chromium Version: 93.0.4577.82
Chromium URL:     https://chromium.googlesource.com/chromium/src.git
                  @f2d6656bdf16198c04b70efd1952dace3ed7dd8f

This distribution contains all components necessary to build and distribute an
application using CEF on the Linux platform. Please see the LICENSING
section of this document for licensing terms and conditions.


CONTENTS
--------

cmake       Contains CMake configuration files shared by all targets.

Debug       Contains libcef.so and other components required to run the debug
            version of CEF-based applications. By default these files should be
            placed in the same directory as libcef.so and will be copied there
            as part of the build process.

include     Contains all required CEF header files.

libcef_dll  Contains the source code for the libcef_dll_wrapper static library
            that all applications using the CEF C++ API must link against.

Release     Contains libcef.so and other components required to run the release
            version of CEF-based applications. By default these files should be
            placed in the same directory as libcef.so and will be copied there
            as part of the build process.

Resources   Contains resources required by libcef.so. By default these files
            should be placed in the same directory as libcef.so and will be
            copied there as part of the build process.

tests/      Directory of tests that demonstrate CEF usage.

  cefclient Contains the cefclient sample application configured to build
            using the files in this distribution. This application demonstrates
            a wide range of CEF functionalities.

  cefsimple Contains the cefsimple sample application configured to build
            using the files in this distribution. This application demonstrates
            the minimal functionality required to create a browser window.

  ceftests  Contains unit tests that exercise the CEF APIs.

  gtest     Contains the Google C++ Testing Framework used by the ceftests
            target.

  shared    Contains source code shared by the cefclient and ceftests targets.


USAGE
-----

Building using CMake:
  CMake can be used to generate project files in many different formats. See
  usage instructions at the top of the CMakeLists.txt file.

Please visit the CEF Website for additional usage information.

https://bitbucket.org/chromiumembedded/cef/


REDISTRIBUTION
--------------

This binary distribution contains the below components.

Required components:

The following components are required. CEF will not function without them.

* CEF core library.
  * libcef.so

* Unicode support data.
  * icudtl.dat

* V8 snapshot data.
  * snapshot_blob.bin
  * v8_context_snapshot.bin

Optional components:

The following components are optional. If they are missing CEF will continue to
run but any related functionality may become broken or disabled.

* Localized resources.
  Locale file loading can be disabled completely using
  CefSettings.pack_loading_disabled. The locales directory path can be
  customized using CefSettings.locales_dir_path. 
 
  * locales/
    Directory containing localized resources used by CEF, Chromium and Blink. A
    .pak file is loaded from this directory based on the value of environment
    variables which are read with the following precedence order: LANGUAGE,
    LC_ALL, LC_MESSAGES and LANG. Only configured locales need to be
    distributed. If no locale is configured the default locale of "en-US" will
    be used. Without these files arbitrary Web components may display
    incorrectly.

* Other resources.
  Pack file loading can be disabled completely using
  CefSettings.pack_loading_disabled. The resources directory path can be
  customized using CefSettings.resources_dir_path.

  * chrome_100_percent.pak
  * chrome_200_percent.pak
  * resources.pak
    These files contain non-localized resources used by CEF, Chromium and Blink.
    Without these files arbitrary Web components may display incorrectly.

* Angle support.
  * libEGL.so
  * libGLESv2.so
  Without these files HTML5 accelerated content like 2D canvas, 3D CSS and WebGL
  will not function.

* SwiftShader support.
  * swiftshader/libEGL.so
  * swiftshader/libGLESv2.so
  Without these files WebGL will not function in software-only mode when the GPU
  is not available or disabled.


LICENSING
---------

The CEF project is BSD licensed. Please read the LICENSE.txt file included with
this binary distribution for licensing terms and conditions. Other software
included in this distribution is provided under other licenses. Please visit
"about:credits" in a CEF-based application for complete Chromium and third-party
licensing information.
