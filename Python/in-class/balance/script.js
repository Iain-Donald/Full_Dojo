/* 
Given an array of ints representing a line of people where the space between
indexes is 1 foot, with 0 meaning no one is there and 1 meaning someone is in
that space,
return whether or not there is at least 6 feet separating every person.
Bonus: O(n) linear time (avoid nested loops that cause re-visiting indexes).
*/

const queue1 = [0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1];
const expected1 = false;

const queue2 = [0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1];
const expected2 = true;

const queue3 = [1, 0, 0, 0, 0, 0, 0, 0, 1];
const expected3 = true;

const queue4 = [];
const expected4 = true;

/*
 * Determines whether each occupied space in the line of people is separated by
 * 6 empty spaces.
 * - Time: O(?).
 * - Space: O(?).
 * @param {Array<0|1>} queue
 * @returns {Boolean}
 */
function socialDistancingEnforcer(queue) {
    var spaceCount = 0;
    var people = false;

    for(var i = 0; i < queue.length; i++){
        if(queue[i] == 0)
            spaceCount += 1;
        else {

            if(spaceCount < 6 && people == true)
                return false;
            people = true;

            spaceCount = 0;
        }
    }
    return true;
}

console.log("---- problem 1 ----");

console.log(socialDistancingEnforcer(queue1));
console.log(socialDistancingEnforcer(queue2));
console.log(socialDistancingEnforcer(queue3));
console.log(socialDistancingEnforcer(queue4));


console.log("---- problem 2 ----");
//  **

/*
  Balance Index
  Here, a balance point is ON an index, not between indices.
  Return the balance index where sums are equal on either side
  (exclude its own value).

  Return -1 if none exist.

*/

const two_nums1 = [-2, 5, 7, 0, 3];
const two_expected1 = 2;

const two_nums3 = [10, 0, 3, 3, 3, 1];
const two_expected3 = 1;

const two_nums2 = [9, 9];
const two_expected2 = -1;

const two_nums4 = [9, 9, 17];
const two_expected4 = -1;

/**
 * Finds the balance index in the given array where the sum to the left of the
 *    index is equal to the sum to the right of the index.
 * - Time: O(?).
 * - Space: O(?).
 * @param {Array<number>} nums
 * @returns {number} The balance index or -1 if there is none.
 */
function balanceIndex(nums) {
    var a = 0;
    var b = 0;

    for(var i = 0; i < nums.length; i++){

        for(var j = 0; j < nums.length; j++){
            if(j < i)
                a += nums[j];
            else if (j > i)
                b += nums[j];
        }

        if(a == b) return i;
        
        a = 0;
        b = 0;
    }
    return -1;
}
console.log(balanceIndex(two_nums1));
console.log(balanceIndex(two_nums3));
console.log(balanceIndex(two_nums2));
console.log(balanceIndex(two_nums4));