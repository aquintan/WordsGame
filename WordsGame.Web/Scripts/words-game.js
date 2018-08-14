window.WordsGameApp = window.WordsGameApp || (function ($) {
    var possibleInitialLetter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    var initialLetter;
    var words = [];
    var counter = 0;
    var counterInitialValue = 30;
    var isPlaying = false;
    var timer;
    var game;

    this.getEventStrings = function () {
        return ["WordsGameAppStart", "WordsGameAppCounterDecreased", "WordsGameAppWordAdded", "WordsGameAppInvalidWord", "WordsGameAppStop"];
    };

    this.isGameRunning = function () {
        return isPlaying;
    };

    this.setCounterStartValue = function (value) {
        if (counter >= 1) {
            counterInitialValue = value;
        }
    };

    this.start = function () {
        if (!isPlaying) {
            $.ajax({
                type: "POST",
                url: "/api/game",
                success: function(data){
                    game = data;
                    initialLetter = getInitialLetter();
                    $(document).trigger("WordsGameAppStart", initialLetter);
                    isPlaying = true;
                    counter = counterInitialValue;
                    words.length = 0;

                    timer = setInterval(decreaseCounter, 1000);     
                },
                error: function() {
                    console.log("Game could not be inititated");
                }
            });
        }
    };

    this.addWord = function (word) {
        if (isPlaying) {
            if (validateWord(word)) {
                words.push(word);
                $(document).trigger("WordsGameAppWordAdded", word, words.slice(0));
            } else {
                $(document).trigger("WordsGameAppInvalidWord", word);
            }
        }
    };

    this.getResult = function () {
        if (counter === 0) {
            return null;
        } else {
            return {
                initialLetter: initialLetter,
                words: words.slice(0)
            };
        }
    };

    function validateWord(word) {
        if (word.charAt(0) !== initialLetter) {
            return false;
        }

        if (words.includes(word)) {
            return false;
        }

        return true;
    }

    function getInitialLetter() {
        return possibleInitialLetter.charAt(Math.floor(Math.random() * possibleInitialLetter.length));
    }

    function decreaseCounter() {
        $(document).trigger("WordsGameAppCounterDecreased", counter);
        if (counter > 0) {
            counter--;
        } else {
            stop();
        }
    }

    function stop() {
        clearInterval(timer);
        isPlaying = false;
        $(document).trigger("WordsGameAppStop");

        $.ajax({
            type: "PUT",
            url: "/api/game/" + game.id,
            data: JSON.stringify(words),
            contentType: 'application/json',
            success: function(){
                console.log("Game data recorded");
            },
            error: function() {
                console.log("Game data could not be stored in server");
            }
        });
    }

    return this;
})(jQuery);