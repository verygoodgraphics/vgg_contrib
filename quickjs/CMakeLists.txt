cmake_minimum_required(VERSION 3.7)

project(vgg_contrib_quickjs)
set(QJS_SRCS
  upstream/quickjs/quickjs.c
  upstream/quickjs/libregexp.c
  upstream/quickjs/libunicode.c
  upstream/quickjs/cutils.c
  upstream/quickjs/quickjs-libc.c
  upstream/quickjs/libbf.c
)

add_library(quickjs STATIC ${QJS_SRCS})
target_compile_options(quickjs PRIVATE
  -D_GNU_SOURCE
  -DCONFIG_BIGNUM
  -DDUMP_LEAKS
)

if (APPLE)
  target_compile_options(quickjs PRIVATE
    -Wno-incompatible-pointer-types-discards-qualifiers
    -Wno-unused-result
  )
elseif(MSVC)
  target_compile_definitions(quickjs PUBLIC JS_STRICT_NAN_BOXING)
  target_compile_options(quickjs PRIVATE
    /wd"4267"
    /wd"4244"
    /wd"4018"
    /wd"4101"
    /wd"4146"
    /wd"4013"
    /wd"4334"
    /wd"4996"
  )
else()
  target_compile_options(quickjs PRIVATE
    -Wno-discarded-qualifiers
    -Wno-unused-result
  )
endif()

set(VGG_CONTRIB_QUICKJS_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream CACHE PATH "" FORCE)
mark_as_advanced(VGG_CONTRIB_QUICKJS_INCLUDE)
