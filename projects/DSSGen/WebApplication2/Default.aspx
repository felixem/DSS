<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication2._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<!-- start page -->
<div id="wrapper">
	<div id="page">
		<!-- start content -->
		<div id="content">
			<div class="post">
				<p class="date">September <b>03</b></p>
				<h2 class="title">Welcome to Our Website!</h2>
				<p class="meta"><small>Posted <a href="#">freewordpressthemes</a> | <a href="#">Edit</a> Filed under <a href="#">WordPress</a>, <a href="#">Internet</a> | <a href="#">No Comments »</a></small></p>
				<div class="entry">
					<p>This is <strong>Interlude</strong>, a free, fully standards-compliant CSS template designed by <a href="http://www.freecsstemplates.org/">Free CSS Templates</a>. This free template is released under a <a href="http://creativecommons.org/licenses/by/2.5/">Creative Commons Attributions 2.5</a>
 license, so you're pretty much free to do whatever you want with it 
(even use it commercially) provided you keep the links in the footer 
intact. Aside from that, have fun with it :)</p>
					<p>This template is also available as a <a href="http://www.freewpthemes.net/preview/Interlude/">WordPress theme</a> at <a href="http://www.freewpthemes.net/">Free WordPress Themes</a>.</p>
				</div>
			</div>
			<div class="post">
				<p class="date">August <b>26</b></p>
				<h2 class="title">Praesent scelerisque scelerisque erat</h2>
				<p class="meta"><small>Posted <a href="#">freewordpressthemes</a> | <a href="#">Edit</a> Filed under <a href="#">WordPress</a>, <a href="#">Internet</a> | <a href="#">No Comments »</a></small></p>
				<div class="entry">
					<p>In posuere eleifend odio. Quisque semper augue mattis wisi. 
Maecenas ligula. Pellentesque viverra vulputate enim. Aliquam erat 
volutpat. Pellentesque tristique ante ut risus. Quisque dictum. Integer 
nisl risus, sagittis convallis, rutrum id, elementum congue, nibh. 
Suspendisse dictum porta lectus. Donec placerat odio vel elit. Nullam 
ante orci, pellentesque eget, tempus quis, ultrices in, est. Curabitur 
sit amet nulla. Nam in massa. </p>
				</div>
			</div>
			<div class="post">
				<p class="date">August <b>22</b></p>
				<h2 class="title">Maecenas luctus lectus at sapien</h2>
				<p class="meta"><small>Posted <a href="#">freewordpressthemes</a> | <a href="#">Edit</a> Filed under <a href="#">WordPress</a>, <a href="#">Internet</a> | <a href="#">No Comments »</a></small></p>
				<div class="entry">
					<p>In posuere eleifend odio. Quisque semper augue mattis wisi. 
Maecenas ligula. Pellentesque viverra vulputate enim. Aliquam erat 
volutpat. Pellentesque tristique ante ut risus. Quisque dictum. Integer 
nisl risus, sagittis convallis, rutrum id, elementum congue, nibh. 
Suspendisse dictum porta lectus. Donec placerat odio vel elit. Nullam 
ante orci, pellentesque eget, tempus quis, ultrices in, est. Curabitur 
sit amet nulla. Nam in massa. </p>
					<p>Pellentesque viverra vulputate enim. Aliquam erat volutpat. 
Pellentesque tristique ante ut risus. Quisque dictum. Integer nisl 
risus, sagittis convallis, rutrum id, elementum congue, nibh. 
Suspendisse dictum porta lectus. Donec placerat odio vel elit. Nullam 
ante orci, pellentesque eget, tempus quis, ultrices in, est. <br>
					</p>
				</div>
			</div>
		</div>
		<!-- end content -->
		<!-- start sidebar -->
		<div id="sidebar">
			<ul>
				<li id="categories">
					<h2>Categories</h2>
					<ul>
						<li><a href="#">Lorem Ipsum</a> (1) </li>
						<li><a href="#">Uncategorized</a> (4) </li>
						<li><a href="#">Nulla luctus eleifend</a> (1) </li>
						<li><a href="#">Pellentesque tempus</a> (4) </li>
						<li><a href="#">Donec dictum metus</a> (1) </li>
						<li><a href="#">Etiam posuere augue</a> (4) </li>
					</ul>
				</li>
				<li id="calendar">
					<h2>Calendar</h2>
					<div id="calendar_wrap">
						<table id="wp-calendar" summary="Calendar">
							<caption>
							September 2008
							</caption>
							<thead>
								<tr>
									<th abbr="Monday" scope="col" title="Monday">M</th>
									<th abbr="Tuesday" scope="col" title="Tuesday">T</th>
									<th abbr="Wednesday" scope="col" title="Wednesday">W</th>
									<th abbr="Thursday" scope="col" title="Thursday">T</th>
									<th abbr="Friday" scope="col" title="Friday">F</th>
									<th abbr="Saturday" scope="col" title="Saturday">S</th>
									<th abbr="Sunday" scope="col" title="Sunday">S</th>
								</tr>
							</thead>
							<tfoot>
								<tr>
									<td abbr="July" colspan="3" id="prev"><a href="#">« Jul</a></td>
									<td class="pad">&nbsp;</td>
									<td abbr="September" colspan="3" id="next" class="pad"><a href="#">Sep »</a></td>
								</tr>
							</tfoot>
							<tbody>
								<tr>
									<td colspan="2" class="pad">&nbsp;</td>
									<td>1</td>
									<td>2</td>
									<td>3</td>
									<td>4</td>
									<td>5</td>
								</tr>
								<tr>
									<td>6</td>
									<td>7</td>
									<td>8</td>
									<td>9</td>
									<td>10</td>
									<td>11</td>
									<td>12</td>
								</tr>
								<tr>
									<td>13</td>
									<td>14</td>
									<td>15</td>
									<td>16</td>
									<td>17</td>
									<td>18</td>
									<td>19</td>
								</tr>
								<tr>
									<td>20</td>
									<td id="today">21</td>
									<td>22</td>
									<td>23</td>
									<td>24</td>
									<td>25</td>
									<td>26</td>
								</tr>
								<tr>
									<td>27</td>
									<td>28</td>
									<td>29</td>
									<td>30</td>
									<td>31</td>
									<td class="pad" colspan="2">&nbsp;</td>
								</tr>
							</tbody>
						</table>
					</div>
				</li>
				<li>
					<h2>Lorem Ipsum Dolor</h2>
					<ul>
						<li><a href="#">Nulla luctus eleifend purus</a></li>
						<li><a href="#">Praesent scelerisque scelerisque erat</a></li>
						<li><a href="#">Ut nonummy rutrum sem</a></li>
						<li><a href="#">Pellentesque tempus quam quis nulla</a></li>
						<li><a href="#">Fusce ultrices fringilla metus</a></li>
						<li><a href="#">Praesent mattis condimentum nisl</a></li>
					</ul>
				</li>
			</ul>
		</div>
		<!-- end sidebar -->
		<br style="clear: both;">
	</div>
</div>
<!-- end page -->
</asp:Content>
