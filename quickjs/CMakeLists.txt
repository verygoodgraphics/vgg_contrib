cmake_minimum_required(VERSION 3.7)

project(vgg_contrib_quickjs)
set(QJS_SRCS
  upstream/quickjs.c
  upstream/libregexp.c
  upstream/libunicode.c
  upstream/cutils.c
  upstream/quickjs-libc.c
  upstream/libbf.c
)

add_library(quickjs STATIC ${QJS_SRCS})
target_compile_options(quickjs PRIVATE
  -D_GNU_SOURCE
  -DCONFIG_VERSION="2022-03-07"
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