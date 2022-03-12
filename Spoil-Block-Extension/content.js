function blurTitle (element) {
    element.style.color = 'transparent';
    element.style.textShadow = '0 0 5px rgba(0,0,0,0.5)';
}

function blurThumbnail (element) {
    element.style.filter = 'blur(10px)';
}

function checkSpoiler(element) {
    let title = element.querySelector("#video-title");
    let thumbnail = element.querySelector("#img");

    let titleText = title.innerHTML.toString().toLowerCase();
    let isSpoiler = false;

    if (titleText.includes('spoiler') && !titleText.includes('no spoiler')) { isSpoiler = true; }
    if (titleText.includes('spoiler-free') || titleText.includes('spoiler free') || titleText.includes('non-spoiler')) {isSpoiler = false; }

    if(isSpoiler) {
        blurTitle(title);
        blurThumbnail(thumbnail);
    }
}

async function IsLoaded() {
//    let el = document.getElementById("contents");
//    if (el) {
//        console.log("loaded");
//        document.getElementById("contents").addEventListener("DOMSubtreeModified", function (event) {
//            let els = document.querySelectorAll('[id=dismissible]');
//            els.forEach(
//                function(currentValue) {
//                    checkSpoiler(currentValue);
//                }
//            )
//        });
//    } else {
//        console.log("Not yet loaded");
//        asyncCall();
//    }
    console.log(location.href);
    console.log("adding listener");
    document.getElementById("contents").addEventListener("DOMNodeInserted", function (event) {
        if (el) {
            let els = document.querySelectorAll('[id=dismissible]');
            els.forEach(
                function(currentValue) {
                    checkSpoiler(currentValue);
                }
            );
        } else {
            console.log("Not yet loaded");
        }
    });
    
    //------------------------------------------------
    let el = document.getElementById("contents");
    
        
    
}

function pageWait() {
return new Promise(resolve => {
    setTimeout(() => {
    IsLoaded();
    }, 200);
});
}
  
async function asyncCall() {
    console.log('calling');
    const result = await pageWait();

    console.log(result);
}

async function checkPageLoad() {
    setTimeout(() => {
        let title = document.getElementById("video-title");
        if (title) {
            if (title.innerHTML === null) {
                console.log("Tried to check contents... wasn't loaded. Running again.");
                setTimeout(() => { checkPageLoad() }, 50)
                //checkPageLoad();
            } else {
                console.log("Tried to check contents... IT'S LOADED! Breaking out of checkPageLoad()");
                IsLoaded();
            }
        } else {
            console.log("title was null. Running again.");
            setTimeout(() => { checkPageLoad() }, 50);
        }
    }, 0);
}

let lastUrl = location.href; 
new MutationObserver(() => {
  const url = location.href;
  if (url !== lastUrl) {
    lastUrl = url;
    onUrlChange();
  }
}).observe(document, {subtree: true, childList: true});

function onUrlChange() {
    location.reload();
}

checkPageLoad();

