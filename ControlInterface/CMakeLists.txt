cmake_minimum_required ( VERSION 2.6 )
set ( CMAKE_CXX_FLAGS "-std=c++11" )

project ( HarbourCrane )
set ( APP_NAME HarbourCrane )

set( CMAKE_BUILD_TYPE RELEASE )

include_directories( ../OuterWorld/include )
include_directories( ../ExpertSystem/include )

set ( EXECUTABLE_OUTPUT_PATH ${PROJECT_SOURCE_DIR}/../bin )

add_executable ( ${APP_NAME} src/main.cpp )

target_link_libraries( ${APP_NAME} OuterWorld ExpertSystem )