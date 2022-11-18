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
  -DCONFIG_VERSION="2021-03-27"
  -DCONFIG_BIGNUM
  -DDUMP_LEAKS
)

if (APPLE)
target_compile_options(quickjs PRIVATE
  -Wno-incompatible-pointer-types-discards-qualifiers
)
else()
target_compile_options(quickjs PRIVATE
  -Wno-discarded-qualifiers
)
endif()

set(VGG_CONTRIB_QUICKJS_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream CACHE PATH "" FORCE)
mark_as_advanced(VGG_CONTRIB_QUICKJS_INCLUDE)