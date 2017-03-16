/*
* Based on "Fisher–Yates shuffle" algorithm https://en.wikipedia.org/wiki/Fisher–Yates_shuffle
* */
var RandomList = function(arr){
    'use strict';
    var cls = {};
    var i=0,rand,sel;

    cls.size = function(){
        return this.list.length;
    };

    cls.init = function(){
        cls.list = arr.slice(0);//Copying variable instead of reference.
    };

    cls.reset = function(){
        i=0,rand=0,sel='';
    };

    cls.getRand = function(){
        var size = cls.size();
        var min,max;
        min = i;
        max = size;
        if(min<max) {
            rand = Math.floor(min + Math.random() * (max - min));
            sel = this.list[rand];
            this.list[rand] = this.list[i];//shuffling value with "random key" & "current iterated key" within the range of pending iterations
            this.list[i] = sel;//shuffling value with "current iterated key" & "random key" within the range of pending iterations
            i++;
        }
        else{
            cls.reset();//Reset again. As, the reservoir is empty
            sel = cls.getRand();
        }

        return sel;
    };

    cls.init();//Initializing class

    return cls;
};

var arr = ["a", "b", "c"];
var randList = new RandomList(arr);
console.log(randList.getRand());
console.log(randList.getRand());
console.log(randList.getRand());
console.log("-----");
console.log(randList.getRand());
console.log(randList.getRand());
console.log(randList.getRand());
console.log("-----");
console.log(randList.getRand());
console.log(randList.getRand());
randList.list.push("d");
randList.list.push("e");
randList.list.push("f");
console.log(randList.getRand());
console.log(randList.getRand());
console.log("Original array unchanged: "+arr);