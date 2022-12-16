
$(document).ready(function() {
	// barChart();
	lineChart();
	// areaChart();
	donutChart();
	pieChart();
  
	$(window).resize(function() {
	//   window.barChart.redraw();
	  window.lineChart.redraw();
	//   window.areaChart.redraw();
	  window.donutChart.redraw();
	  window.pieChart.redraw();
	});
  });
  
//   function barChart() {
// 	window.barChart = Morris.Bar({
// 	  element: 'bar-chart',
// 	  data: [
// 		{ y: '2006', a: 100, b: 90 },
// 		{ y: '2007', a: 75,  b: 65 },
// 		{ y: '2008', a: 50,  b: 40 },
// 		{ y: '2009', a: 75,  b: 65 },
// 		{ y: '2010', a: 50,  b: 40 },
// 		{ y: '2011', a: 75,  b: 65 },
// 		{ y: '2012', a: 100, b: 90 }
// 	  ],
// 	  xkey: 'y',
// 	  ykeys: ['a', 'b'],
// 	  labels: ['Series A', 'Series B'],
// 	  lineColors: ['#6576e9','#cdc6c6'],
// 	  lineWidth: '3px',
// 	  resize: true,
// 	  redraw: true
// 	});
//   }
  
  function lineChart() {
	window.lineChart = Morris.Line({
	  element: 'line-chart',
	  data: [
		{ y: '2006', a: 100, b: 90 },
		{ y: '2007', a: 75,  b: 65 },
		{ y: '2008', a: 50,  b: 40 },
		{ y: '2009', a: 75,  b: 65 },
		{ y: '2010', a: 50,  b: 40 },
		{ y: '2011', a: 75,  b: 65 },
		{ y: '2012', a: 100, b: 90 }
	  ],
	  xkey: 'y',
	  ykeys: ['a', 'b'],
	  labels: ['Series A', 'Series B'],
	  lineColors: ['#009688','#cdc6c6'],
	  lineWidth: '3px',
	  resize: true,
	  redraw: true
	});
  }
  
//   function areaChart() {
// 	window.areaChart = Morris.Area({
// 	  element: 'area-chart',
// 	  data: [
// 		{ y: '2006', a: 100, b: 90 },
// 		{ y: '2007', a: 75,  b: 65 },
// 		{ y: '2008', a: 50,  b: 40 },
// 		{ y: '2009', a: 75,  b: 65 },
// 		{ y: '2010', a: 50,  b: 40 },
// 		{ y: '2011', a: 75,  b: 65 },
// 		{ y: '2012', a: 100, b: 90 }
// 	  ],
// 	  xkey: 'y',
// 	  ykeys: ['a', 'b'],
// 	  labels: ['Series A', 'Series B'],
// 	  lineColors: ['#cdc6c6','#009688'],
// 	  lineWidth: '3px',
// 	  resize: true,
// 	  redraw: true
// 	});
//   }
  
  function donutChart() {
	window.donutChart = Morris.Donut({
	element: 'donut-chart',
	data: [
	  {label: "Normal Room", value: 50},
	  {label: "Ac Room", value: 25},
	  {label: "Special Room", value: 5},
	  {label: "DoubleBed room", value: 10},
	  {label: "Video Room", value: 10},
	  
	],
	backgroundColor: '#f2f5fa',
	  labelColor: '#009688',
	 colors: [
	  '#0BA462',
	  '#39B580',
	  '#67C69D',
	  '#95D7BB'
	 ],
	resize: true,
	redraw: true
  });
  }
  
  function pieChart() {
	var paper = Raphael("pie-chart");
  paper.piechart(
	100, // pie center x coordinate
	100, // pie center y coordinate
	90,  // pie radius
	 [18.373, 18.686, 2.867, 23.991, 9.592, 0.213], // values
	 {
	 legend: ["Windows/Windows Live", "Server/Tools", "Online Services", "Business", "Entertainment/Devices", "Unallocated/Other"]
	 }
   );
  }




//   var options = {
// 	series: [44, 55, 13, 43, 22],
// 	chart: {
// 	width: 380,
// 	type: 'pie',
//   },
//   labels: ['Team A', 'Team B', 'Team C', 'Team D', 'Team E'],
//   responsive: [{
// 	breakpoint: 480,
// 	options: {
// 	  chart: {
// 		width: 200
// 	  },
// 	  legend: {
// 		position: 'bottom'
// 	  }
// 	}
//   }]
//   };

//   var chart = new ApexCharts(document.querySelector("#chart"), options);
//   chart.render();

//   var options = {
// 	chart: {
// 	  height: 380,
// 	  type: "line"
// 	},
// 	series: [
// 	  {
// 		name: "Website Blog",
// 		type: "column",
// 		data: [440, 505, 414, 671, 227, 413, 201, 352, 752, 320, 257, 160]
// 	  },
// 	  {
// 		name: "Social Media",
// 		type: "column",
// 		data: [23, 42, 35, 27, 43, 22, 17, 31, 22, 22, 12, 16]
// 	  }
// 	],
// 	stroke: {
// 	  width: [0, 4],
// 	  curve: 'smooth'
// 	},
// 	title: {
// 	  text: "Traffic Sources"
// 	},
// 	// labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
// 	labels: [
// 	  "01 Jan 2001",
// 	  "02 Jan 2001",
// 	  "03 Jan 2001",
// 	  "04 Jan 2001",
// 	  "05 Jan 2001",
// 	  "06 Jan 2001",
// 	  "07 Jan 2001",
// 	  "08 Jan 2001",
// 	  "09 Jan 2001",
// 	  "10 Jan 2001",
// 	  "11 Jan 2001",
// 	  "12 Jan 2001"
// 	],
// 	xaxis: {
// 	  type: "datetime"
// 	},
// 	yaxis: [
// 	  {
// 		title: {
// 		  text: "Website Blog"
// 		}
// 	  },
// 	  {
// 		opposite: true,
// 		title: {
// 		  text: "Social Media"
// 		}
// 	  }
// 	]
//   };
  
//   var chart = new ApexCharts(document.querySelector("#chart"), options);
  
//   chart.render();
  




















