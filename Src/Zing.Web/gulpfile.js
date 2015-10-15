var gulp = require("gulp"),
    concat = require("gulp-concat"),
    uglify = require("gulp-uglify"),
    cssmin = require("gulp-cssmin"),
    jsHint = require("jshint-stylish"),
    del = require("del"),
    sourcemaps = requier("gulp-sourcemaps");

var config = {
    js_dest: "scripts",
    path: {
        jquery: {
            src: [""],
            dest: "*.min.js"
        }
    }
};


gulp.task("jQuery", ["clean"], function () {
    return gulp.src(config.path.jquery.src)
    .pipe(concat(config.path.jquery.dest))
    .pipe(gulp.dest(config.js_dest));
});

gulp.task("default", ["jQuery"]);