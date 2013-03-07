function sack(file) {
	this.xmlhttp = null;

	this.resetData = function() {
		this.method = "POST";
  		this.queryStringSeparator = "?";
		this.argumentSeparator = "&";
		this.URLString = "";
		this.encodeURIString = true;
  		this.execute = false;
  		this.element = null;
		this.elementObj = null;
		this.requestFile = file;
		this.vars = new Object();
		this.responseStatus = new Array(2);
  	};

	this.resetFunctions = function() {
  		this.onLoading = function() { };
  		this.onLoaded = function() { };
  		this.onInteractive = function() { };
  		this.onCompletion = function() { };
  		this.onError = function() { };
		this.onFail = function() { };
	};

	this.reset = function() {
		this.resetFunctions();
		this.resetData();
	};

	this.createAJAX = function() {
		try {
			this.xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
		} catch (e1) {
			try {
				this.xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
			} catch (e2) {
				this.xmlhttp = null;
			}
		}

		if (! this.xmlhttp) {
			if (typeof XMLHttpRequest != "undefined") {
				this.xmlhttp = new XMLHttpRequest();
			} else {
				this.failed = true;
			}
		}
	};

	this.setVar = function(name, value){
		this.vars[name] = Array(value, false);
	};

	this.encVar = function(name, value, returnvars) {
		if (true == returnvars) {
			return Array(encodeURIComponent(name), encodeURIComponent(value));
		} else {
			this.vars[encodeURIComponent(name)] = Array(encodeURIComponent(value), true);
		}
	}

	this.processURLString = function(string, encode) {
		encoded = encodeURIComponent(this.argumentSeparator);
		regexp = new RegExp(this.argumentSeparator + "|" + encoded);
		varArray = string.split(regexp);
		for (i = 0; i < varArray.length; i++){
			urlVars = varArray[i].split("=");
			if (true == encode){
				this.encVar(urlVars[0], urlVars[1]);
			} else {
				this.setVar(urlVars[0], urlVars[1]);
			}
		}
	}

	this.createURLString = function(urlstring) {
		if (this.encodeURIString && this.URLString.length) {
			this.processURLString(this.URLString, true);
		}

		if (urlstring) {
			if (this.URLString.length) {
				this.URLString += this.argumentSeparator + urlstring;
			} else {
				this.URLString = urlstring;
			}
		}

		// prevents caching of URLString
		this.setVar("rndval", new Date().getTime());

		urlstringtemp = new Array();
		for (key in this.vars) {
			if (false == this.vars[key][1] && true == this.encodeURIString) {
				encoded = this.encVar(key, this.vars[key][0], true);
				delete this.vars[key];
				this.vars[encoded[0]] = Array(encoded[1], true);
				key = encoded[0];
			}

			urlstringtemp[urlstringtemp.length] = key + "=" + this.vars[key][0];
		}
		if (urlstring){
			this.URLString += this.argumentSeparator + urlstringtemp.join(this.argumentSeparator);
		} else {
			this.URLString += urlstringtemp.join(this.argumentSeparator);
		}
	}

	this.runResponse = function() {
		eval(this.response);
	}

	this.runAJAX = function(urlstring) {
		if (this.failed) {
			this.onFail();
		} else {
			this.createURLString(urlstring);
			if (this.element) {
				this.elementObj = document.getElementById(this.element);
			}
			if (this.xmlhttp) {
				var self = this;
				if (this.method == "GET") {
					totalurlstring = this.requestFile + this.queryStringSeparator + this.URLString;
					this.xmlhttp.open(this.method, totalurlstring, true);
				} else {
					this.xmlhttp.open(this.method, this.requestFile, true);
					try {
						this.xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded")
					} catch (e) { }
				}

				this.xmlhttp.onreadystatechange = function() {
					switch (self.xmlhttp.readyState) {
						case 1:
							self.onLoading();
							break;
						case 2:
							self.onLoaded();
							break;

						case 3:
							self.onInteractive();
							break;
						case 4:
							self.response = self.xmlhttp.responseText;
							self.responseXML = self.xmlhttp.responseXML;
							self.responseStatus[0] = self.xmlhttp.status;
							self.responseStatus[1] = self.xmlhttp.statusText;

							if (self.execute) {
								self.runResponse();
							}

							if (self.elementObj) {
								elemNodeName = self.elementObj.nodeName;
								elemNodeName.toLowerCase();
								if (elemNodeName == "input"
								|| elemNodeName == "select"
								|| elemNodeName == "option"
								|| elemNodeName == "textarea") {
									self.elementObj.value = self.response;
								} else {
									self.elementObj.innerHTML = self.response;
								}
							}
							if (self.responseStatus[0] == "200") {
								self.onCompletion();
							} else {
								self.onError();
							}

							self.URLString = "";
							break;
					}	
				};

				this.xmlhttp.send(this.URLString);
			}
		}
	};

	this.reset();
	this.createAJAX();
}

function createStates(index,state_id)
{
	var obj = document.getElementById('state_id');
	eval(ajax[index].response);	// Executing the response from Ajax as Javascript code
	
	if (ajax[index].response == "")
	{
		document.getElementById('state_id').style.display = "none";
		if(document.getElementById('state_name'))
		{
			document.getElementById('state_name').style.display = "block";
			document.getElementById('state_name').value = "";
		}
	}
	else
	{
		document.getElementById('state_id').style.display = "block";
		if(document.getElementById('state_name'))
		{
			document.getElementById('state_name').style.display = "none";
			document.getElementById('state_name').value = "";
		}
	}
	
	for (i = 0; i < obj.length; i++)
	{
		if  (obj.options[i].value==state_id)
		{
			obj.options[i].selected = true;
		}
	}
}


function changeImg (id,on) {
	obj = document.getElementById(id);
	if (on)
		obj.src = obj.src.replace ("out","over");
	else
		obj.src = obj.src.replace ("over","out");
};


function showPreviw(x) {
    var item    = 'item'+x;
    var preview = 'preview'+x;
    document.getElementById(item).style.display    = "none";
    document.getElementById(preview).style.display = "block";
}

function hidePreviw(x) {
    var item    = 'item'+x;
    var preview = 'preview'+x;
    document.getElementById(item).style.display    = "block";
    document.getElementById(preview).style.display = "none";
}

function send_message()
{
	var subject = document.getElementById('subject').value;
	var last_name = document.getElementById('last_name').value;
	var first_name = document.getElementById('first_name').value;
	var email = document.getElementById('email').value;
	var message = document.getElementById('message').value;
	filter   = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
	var error = '';
	if (first_name == '') error += "Your first name is required! \n";
	if (last_name == '') error += "Your last name is required! \n";
	if (email == '')
	{
		error += "Your email address is required! \n";
	}
	else
	{
		if(filter.test(email) == false) error += "Please provide a valid email address! \n";
	}
	if (subject == '') error += "Subject is required! \n";
	if (message == '') error += "Message is required!";
	
	
	if (error != '') alert(error);
	else document.forms['contact'].submit();
}


function order_message()
{
	var last_name = document.getElementById('last_name').value;
	var first_name = document.getElementById('first_name').value;
	var email = document.getElementById('email').value;
	var message = document.getElementById('message').value;
	filter   = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
	var error = '';
	if (first_name == '') error += "Your first name is required! \n";
	if (last_name == '') error += "Your last name is required! \n";
	if (email == '')
	{
		error += "Your email address is required! \n";
	}
	else
	{
		if(filter.test(email) == false) error += "Please provide a valid email address! \n";
	}
	if (message == '') error += "Message is required!";
	
	if (error != '') alert(error);
	else document.forms['contact'].submit();
}

var ajax = new Array();

function getCitiesList(sel,city_id, objectName)
{
	var state_id = sel.options[sel.selectedIndex].value;
	document.getElementById(objectName).style.display = "";
	document.getElementById(objectName).options.length = 0;	// Empty state select box
	if(state_id.length>0){
		var index = ajax.length;
		ajax[index] = new sack();
			
		ajax[index].requestFile = 'http://www.myvisuallistings.com/realestate-virtual-tours/getcities/'+state_id;	// Specifying which file to get
		ajax[index].onCompletion = function(){ createCities(index,city_id,objectName) };	// Specify function that will be executed after file has been found
		ajax[index].runAJAX();		// Execute AJAX function
	}
}

function getStatesList(sel,state_id)
{
	var country_id = sel.options[sel.selectedIndex].value;
	document.getElementById('state_id').options.length = 0;	// Empty state select box
	if(country_id.length>0){
		
		var index = ajax.length;
		ajax[index] = new sack();
			
		ajax[index].requestFile = 'http://www.myvisuallistings.com/realestate-virtual-tours/getstates/'+country_id;	// Specifying which file to get
		ajax[index].onCompletion = function(){ createStates(index,state_id) };	// Specify function that will be executed after file has been found
		ajax[index].runAJAX();		// Execute AJAX function
	}
}

function lookup(inputString) {
	if(inputString.length == 0) {
		// Hide the suggestion box.
		$('#suggestions').hide();
	} else {
		var dropdownIndex = document.getElementById('state_id').selectedIndex;
		var State = document.getElementById('state_id')[dropdownIndex].value;
		$.post("http://www.myvisuallistings.com/realestate-virtual-tours/ajax-city-list/"+State + "/"+inputString, {queryString: ""}, function(data){
			if(data.length >0) {
				$('#suggestions').show();
				$('#autoSuggestionsList').html(data);
			}
		});
	}
} // lookup

function fill(thisValue,thisId) {
	$('#city_name').val(thisValue);
	$('#city_id').val(thisId);
	setTimeout("$('#suggestions').hide();", 200);
}




hs.graphicsDir = 'http://www.myvisuallistings.com/highslide-v4/graphics/';
	hs.align = 'center';
	hs.transitions = ['expand', 'crossfade'];
	hs.outlineType = 'rounded-white';
	hs.fadeInOut = true;
	hs.numberPosition = 'caption';
	hs.dimmingOpacity = 0.75;

	// Add the controlbar
	if (hs.addSlideshow) hs.addSlideshow({
		//slideshowGroup: 'group1',
		interval: 5000,
		repeat: false,
		useControls: true,
		fixedControls: true,
		overlayOptions: {
			opacity: .75,
			position: 'top center',
			hideOnMouseOut: true
		}
	});


function aclick(anchor_id) {
	var a = document.getElementById(anchor_id);
	hs.expand(a);
}


function openNewWindow(URL, w,h)
{
	window.open(URL,"NewWindow","resizable=yes,toolbar=no,locationbar=no,menubar=no,scrollbars=no,status=no,height="+h+",width="+w);
}

function openNewWindowScroll(URL, w,h)
{
	window.open(URL,"NewWindow","resizable=yes,toolbar=no,locationbar=no,menubar=no,scrollbars=yes,status=no,height="+h+",width="+w);
}
