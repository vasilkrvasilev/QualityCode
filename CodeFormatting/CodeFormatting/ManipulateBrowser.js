// Group the code in a function - manipulateBrowser()
// Add 'use strict'
// Extract 'Netscape' as a variable browserToManipulate
// Add var before the names of the variable declaration
// Use only dot notation to access object properties
// Use === instead of ==
// Rename pX and pY to positionX and positionY
// Delete var off=0;, var txt="", args=HideTip.arguments; which are not used
// Use camalCase instead PascalCase for the names of the functions
// functions hideTip, hideMenu1, showMenu1, hideMenu2, and showMenu2 are not used.

function manipulateBrowser() {
    'use strict';

    var browserToManipulate = 'Netscape';
    var browser = navigator.appName;
    var addScroll = false;
    var theLayer;

    if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
        addScroll = true;
    }

    var positionX = 0;
    var positionY = 0;
    document.onmousemove = mouseMove;

    if (browser === browserToManipulate) {
        document.captureEvents(Event.MOUSEMOVE);
    }

    function mouseMove(browserEvent) {
        if (browser === browserToManipulate) {
            positionX = browserEvent.pageX - 5;
            positionY = browserEvent.pageY;
        } else {
            positionX = event.x - 5;
            positionY = event.y;
        }

        if (browser === browserToManipulate) {
            if (document.layers.ToolTip.visibility === 'show') {
                popTip();
            }
        } else {
            if (document.all.ToolTip.style.visibility === 'visible') {
                popTip();
            }
        }
    }

    function popTip() {
        if (browser === browserToManipulate) {
            theLayer = document.layers.ToolTip;
            if ((positionX + 120) > window.innerWidth) {
                positionX = window.innerWidth - 150;
            }

            theLayer.left = positionX + 10;
            theLayer.top = positionY + 15;
            theLayer.visibility = 'show';
        } else {
            theLayer = document.all.ToolTip;
            if (theLayer) {
                positionX = event.x - 5;
                positionY = event.y;

                if (addScroll) {
                    positionX = positionX + document.body.scrollLeft;
                    positionY = positionY + document.body.scrollTop;
                }

                if ((positionX + 120) > document.body.clientWidth) {
                    positionX = positionX - 150;
                }

                theLayer.style.pixelLeft = positionX + 10;
                theLayer.style.pixelTop = positionY + 15;
                theLayer.style.visibility = 'visible';
            }
        }
    }

    function hideTip() {
        if (browser === browserToManipulate) {
            document.layers.ToolTip.visibility = 'hide';
        } else {
            document.all.ToolTip.style.visibility = 'hidden';
        }
    }

    function hideMenu1() {
        if (browser === browserToManipulate) {
            document.layers.menu1.visibility = 'hide';
        } else {
            document.all.menu1.style.visibility = 'hidden';
        }
    }

    function showMenu1() {
        if (browser === browserToManipulate) {
            theLayer = document.layers.menu1;
            theLayer.visibility = 'show';
        } else {
            theLayer = document.all.menu1;
            theLayer.style.visibility = 'visible';
        }
    }

    function hideMenu2() {
        if (browser === browserToManipulate) {
            document.layers.menu2.visibility = 'hide';
        } else {
            document.all.menu2.style.visibility = 'hidden';
        }
    }

    function showMenu2() {
        if (browser === browserToManipulate) {
            theLayer = document.layers.menu2;
            theLayer.visibility = 'show';
        } else {
            theLayer = document.all.menu2;
            theLayer.style.visibility = 'visible';
        }
    }
}