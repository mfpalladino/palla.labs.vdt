const Webpack = require('webpack'),
      ExtractTextPlugin = require('extract-text-webpack-plugin'),
      CopyWebpackPlugin = require('copy-webpack-plugin'),
      CleanWebpackPlugin = require('clean-webpack-plugin'),
      OpenBrowserPlugin = require('open-browser-webpack-plugin');

module.exports = {
    entry: ['./app/app.js'],
    devtool: 'source-map',
    output: {
        path: './public',
        filename: '/js/bundle.js'
    },
    plugins: [
          new Webpack.DefinePlugin({
              'process.env': { NODE_ENV: JSON.stringify(process.env.NODE_ENV || 'development') }
          }),
          new CleanWebpackPlugin(['public/app/views', 'public/app/templates', 'public/app/index.html', 'public/app/login.html'], {}),
          new ExtractTextPlugin('/assets/[name].css'),
          new CopyWebpackPlugin(
          [
              { from: 'app/views', to: 'views' },
              { from: 'app/templates', to: 'templates' },
              { from: 'app/index.html', to: 'index.html' },
              { from: 'app/login.html', to: 'login.html' }
          ]),
          new OpenBrowserPlugin({ url: 'http://localhost:3000/index.html' })
    ],
    module: {
        loaders: [
          { test: /\.less$/, exclude: '/node_modules/', loader: ExtractTextPlugin.extract('style-loader', 'css-loader!less-loader') },
          { test: /\.(eot|woff|woff2|ttf|svg|png|jpg)$/, exclude: '/node_modules/', loader: 'url-loader?limit=30000&name=/assets/[name]-[hash].[ext]' },
		  {
			test: /bundle\.js$/,
			loader: 'string-replace',
			query: {
				search: '##endereco_api##',
				replace: 'http://localhost:52300/'
			}		  
		  }
        ]
    },
    devServer: {
        contentBase: './public',
        hot: true
    }
};