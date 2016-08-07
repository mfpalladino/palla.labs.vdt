const Webpack = require('webpack'),
	  ExtractTextPlugin = require('extract-text-webpack-plugin'),
	  CleanWebpackPlugin = require('clean-webpack-plugin'),
	  OptimizeCssAssetsPlugin = require('optimize-css-assets-webpack-plugin'),
	  CopyWebpackPlugin = require('copy-webpack-plugin');

var realFs = require('fs')
var gracefulFs = require('graceful-fs')
gracefulFs.gracefulify(realFs)

module.exports = {
    entry: ['./app/app.js'],
    devtool: 'source-map',
    output: {
        path: './public',
        filename: '/js/bundle.js'
    },
    plugins: [
          new Webpack.DefinePlugin({
              'process.env.NODE_ENV': JSON.stringify('production')
          }),
          new CleanWebpackPlugin(['public'], {}),
          new ExtractTextPlugin('/assets/[name].css'),
		  new Webpack.optimize.UglifyJsPlugin({
			sourceMap: false,
			mangle: false,
			minimize: true,
			compress:{
				warnings: false
			}			
		  }),		  
		  new OptimizeCssAssetsPlugin({
			  assetNameRegExp: /\.css$/g,
			  cssProcessor: require('cssnano'),
			  cssProcessorOptions: { discardComments: {removeAll: true } },
			  canPrint: true
		  }),		  
          new CopyWebpackPlugin(
          [
              { from: 'app/views', to: 'views' },
              { from: 'app/templates', to: 'templates' },
              { from: 'app/index.html', to: 'index.html' },
              { from: 'app/login.html', to: 'login.html' },
              { from: './bower_components', to: 'bower_components' },
              { from: './custom_components', to: 'custom_components' }
          ])
    ],
    module: {
        loaders: [
          { test: /\.less$/, exclude: '/node_modules/', loader: ExtractTextPlugin.extract('style-loader', 'css-loader!less-loader') },
          { test: /\.(eot|woff|woff2|ttf|svg|png|jpg)$/, exclude: '/node_modules/', loader: 'url-loader?limit=30000&name=/assets/[name]-[hash].[ext]' },
		  {
			test: /constantesService\.js$/,
			loader: 'string-replace',
			query: {
				search: '##endereco_api##',
				replace: 'http://vendeta.azurewebsites.net/server/'
			}		  
		  }
        ]
    }
};