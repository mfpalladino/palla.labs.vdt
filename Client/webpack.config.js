const Webpack = require('webpack'),
	  ExtractTextPlugin = require('extract-text-webpack-plugin'),
	  CleanWebpackPlugin = require('clean-webpack-plugin'),
	  CopyWebpackPlugin = require('copy-webpack-plugin');

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
		      minimize: true,
		      compress: {
		          warnings: false
		      }
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
          { test: /\.(eot|woff|woff2|ttf|svg|png|jpg)$/, exclude: '/node_modules/', loader: 'url-loader?limit=30000&name=/assets/[name]-[hash].[ext]' }
        ]
    }
};