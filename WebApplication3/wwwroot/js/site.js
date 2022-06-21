// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function (event) {
    var app = new Vue({
        el: "#chatApp",
        data: {
            userName: "",
            userMessage: "",
            connection: "",
            messages: []
        },
        methods: {
            submitCard: function () {
                if (this.userName && this.userMessage) {
                    // ---------
                    //  Call hub methods from client
                    // ---------
                    this.connection
                        .invoke("SendMessage", this.userName, this.userMessage)
                        .catch(function (err) {
                            return console.error(err.toSting());
                        });

                    this.userName = "";
                    this.userMessage = "";
                }
            }
        },
        created: function () {
            // ---------
            // Connect to our hub
            // ---------
            this.connection = new signalR.HubConnectionBuilder()
                .withUrl("/chatHub")
                .configureLogging(signalR.LogLevel.Information)
                .build();
            this.connection.start().catch(function (err) {
                return console.error(err.toSting());
            });
        },
        mounted: function () {
            // ---------
            // Call client methods from hub
            // ---------
            this.$nextTick(() => {
                var thisVue = this;
                


                thisVue.connection.on("ReceiveMessage", function (user, message) {
                    thisVue.messages.push({ user, message });
                });
            });
        }
    });
});