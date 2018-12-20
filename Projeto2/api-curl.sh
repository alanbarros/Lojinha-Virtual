#!/bin/bash

json = "{'username':${1},'password':${2}}";

$(curl --header "Content-Type: application/json" --request POST --data ${json} http://localhost:5000/api/Usuarios´
