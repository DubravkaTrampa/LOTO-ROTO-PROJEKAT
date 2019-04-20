var totalnumbers = 7 //input total numbers to generate
var lowerbound = 1   //input lower bound for each random number
var upperbound = 39  //input upper bound for each random number

function lotto() {
    B = ' ';
    LottoNumbers = new Array();
    for (i = 1; i <= totalnumbers; i++) {
        RandomNumber = Math.round(lowerbound + Math.random() * (upperbound - lowerbound));
        for (j = 1; j <= totalnumbers; j) {
            if (RandomNumber == LottoNumbers[j]) {
                RandomNumber = Math.round(lowerbound + Math.random() * (upperbound - lowerbound));
                j = 0;
            }
            j++;
        }
        LottoNumbers[i] = RandomNumber;
    }
    LottoNumbers = LottoNumbers.toString();
    X = LottoNumbers.split(',');

    for (i = 1; i < X.length; i++) {
        X[i] = X[i] + ' ';
        if (X[i].length == 2)
            X[i] = '0' + X[i];
    }
    X = X.sort();

    for (i = 1; i < X.length; i++) {
        document.getElementById("loptica_" + (i)).dataset.number = X[i];
    }
  
    T = setTimeout('lotto()', 20);
}
function StOp() {
    setTimeout('clearTimeout(T)', 1000);
}