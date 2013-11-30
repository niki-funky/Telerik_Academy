/// <reference path="external/jquery-2.0.2.intellisense.js" />
/// <reference path="class.js" />
 
var pubnubRequesters = (function () {

    // Initialize the PubNub API connection.
    var pubnub = PUBNUB.init({
        publish_key: 'pub-c-4331b990-8629-4f47-9669-51f0e2ee9c9d',
        subscribe_key: 'sub-c-bfd2fbba-0428-11e3-91de-02ee2ddab7fe'
    });
        
    // Grab references for all of our elements.
    //var messageContent = $('#messageContent'),
    var sendMessageButton = $('.sendMsgBtn');
    var messageList = $('#messageList');

    
    // Handles all the messages coming in from pubnub.subscribe.
    function handleMessage(message) {
        var messageEl = $("<li class='message'>"
        + "<span class='username'>" + message.username + ": </span>"
        + message.text
        + "</li>");

        $('#messageList').append(messageEl);       

        
        //messageList.listview('refresh');      

        // Scroll to bottom of page
        //$("html, body").animate({ scrollTop: $(document).height() - $(window).height() }, 'slow');
    };

    var PubnubInstance = Class.create({
        init: function (channelName) {
            this.channel = channelName;
        },
        sendMessage: function (message) {
            if (message != '') {
                pubnub.publish({
                    channel: this.channel,
                    message: {
                        username: localStorage.getItem("username"), // hard-coded: not beautiful
                        text: message
                    }
                });
            }
        },
        getMessages: function () {
            pubnub.subscribe({
                channel: this.channel,
                message: handleMessage
            });
        }
    });   
      

    return {
        get: function (channelName) {
            return new PubnubInstance(channelName);
        }
    };
}());