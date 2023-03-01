cmake_minimum_required(VERSION 3.7)

project(vgg_contrib_json_schema_validator)

add_subdirectory(upstream)

set(VGG_CONTRIB_JSON_SCHEMA_VALIDATOR_INCLUDE ${CMAKE_CURRENT_SOURCE_DIR}/upstream/src CACHE PATH "" FORCE)
mark_as_advanced(VGG_CONTRIB_JSON_SCHEMA_VALIDATOR_INCLUDE)
