cmake_minimum_required ( VERSION 2.6 )
set ( CMAKE_CXX_FLAGS "-std=c++11" )

project ( OuterWorld )
set ( LIB_NAME OuterWorld )
set ( LIB_TYPE STATIC )

set( CMAKE_BUILD_TYPE RELEASE )

include_directories ( ${PROJECT_SOURCE_DIR}/include )

set ( SOURCE ${PROJECT_SOURCE_DIR}/src/outerworld.cpp )

add_library( ${LIB_NAME} ${LIB_TYPE} ${SOURCE} )