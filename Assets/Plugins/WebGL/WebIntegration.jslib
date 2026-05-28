mergeInto(LibraryManager.library, {
    SendPracticeComplete: function (score) {
        if (typeof window !== 'undefined' && window.parent) {
            window.parent.postMessage({
                type: 'PRACTICE_COMPLETED',
                score: score
            }, '*');
        }
    }
});
