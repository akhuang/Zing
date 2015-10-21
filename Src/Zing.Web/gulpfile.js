/// <reference path="bower_components/qtip2/jquery.qtip.min.js" />
/// <reference path="bower_components/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js" />
/// <reference path="bower_components/jquery-validation/dist/jquery.validate.min.js" />
var gulp = require("gulp"),
    concat = require("gulp-concat"),
    uglify = require("gulp-uglify"),
    cssmin = require("gulp-cssmin"),
    jsHint = require("jshint-stylish"),
    del = require("del"),
    sourcemaps = require("gulp-sourcemaps");

var config = {
    js_dest: "Scripts",
    css_dest: "Content",
    fonts_dest: "fonts",
    path: {
        jquery: {
            src: ["bower_components/jQuery/dist/jquery.min.js", "bower_components/jquery-validation/dist/jquery.validate.min.js",
                   "bower_components/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js"],
            dest: "jQuery.min.js"
        },
        bootstrapjs: {
            src: ["bower_components/bootstrap/dist/js/bootstrap.min.js"]
        },
        qtip: {
            src: ["bower_components/qtip2/jquery.qtip.min.js", "bower_components/qtip2/jquery.qtip.min.map"]
        },
        bootstrapcss: {
            src: ["bower_components/bootstrap/dist/css/bootstrap.min.css", "bower_components/qtip2/jquery.qtip.min.css", "bower_components/fontawesome/css/font-awesome.min.css"],
            dest: "bootstrap.min.css"
        },
        fonts: {
            src: ["bower_components/fontawesome/fonts/fontawesome-webfont.woff2", "bower_components/fontawesome/fonts/fontawesome-webfont.woff", "bower_components/fontawesome/fonts/fontawesome-webfont.ttf"]
        }
    }
};


gulp.task("jQuery", function () {
    return gulp.src(config.path.jquery.src)
    .pipe(concat(config.path.jquery.dest))
    .pipe(gulp.dest(config.js_dest));
});
gulp.task("bootstrap", function () {
    return gulp.src(config.path.bootstrapjs.src)
    .pipe(gulp.dest(config.js_dest));
});
gulp.task("qtip", function () {
    return gulp.src(config.path.qtip.src)
    .pipe(gulp.dest(config.js_dest));
});
gulp.task("fonts", function () {
    return gulp.src(config.path.fonts.src)
    .pipe(gulp.dest(config.fonts_dest));
});

gulp.task("bootstrapcss", function () {
    return gulp.src(config.path.bootstrapcss.src)
        .pipe(concat(config.path.bootstrapcss.dest))
    .pipe(gulp.dest(config.css_dest));
});
gulp.task("default", ["jQuery", "bootstrap", "qtip", "bootstrapcss", "fonts"]);