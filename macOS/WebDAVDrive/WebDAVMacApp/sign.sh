find "$1/WebDAV Drive.app" -iname '*.dylib' | while read libfile ; do codesign --force --sign - -o runtime  --timestamp "${libfile}" ; done ;
